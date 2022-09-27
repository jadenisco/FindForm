//#define MGH
#define CONSOLE_INPUT

using System;
using System.IO;

namespace FindForm {
    class Program {
#if MGH
        private static String vol_root_dir = "//Cifs2/voldept$";
        private static String? pet_volunteer_dir = vol_root_dir + "/.Volunteer Files/Pet Therapy";
#else
        private static String vol_root_dir = "/Users/jdenisco/Developer/Windows/testroot";
        private static String? pet_volunteer_root_dir = null;
#endif
        private static String adult_volunteer_root_dir = vol_root_dir + "/.Volunteer Files/ADULT MEDICAL AND NONMEDICAL";
        private static String junior_volunteer_root_dir = vol_root_dir + "/.Volunteer Files/JUNIOR MEDICAL AND NONMEDICAL/Active JR Volunteers";
        private static String path = adult_volunteer_root_dir;
        private static (String vol_num, String dateAsString)[] formInfo = {("456", "1234567"),
                                                                            ("350", "11/18/2021"),
                                                                            ("123", "04/11"),
                                                                            ("0725", "6/11/2022"),
                                                                            ("342", "1/9/2022")};
        private static int formInfoIndex = 0;

        static void Main() {

            GetInfo();
#if JAD
            Console.WriteLine("PATH: '{0}'", path);
            if(File.Exists(path)) {
                ProcessFile(path);
            } else if (Directory.Exists(path)){
                ProcessDirectory(path);

            }
#endif
        }

        private static void ProcessFile(string path) {
            Console.WriteLine("    FILE: '{0}'", path);
        }

        private static void ProcessDirectory(string targetDirectory) {
            Console.WriteLine("  DIR: '{0}", targetDirectory);
            string [] fileEntries = Directory.GetFiles(targetDirectory);
            foreach(string fileName in fileEntries) {
                ProcessFile(fileName);
            }

            string [] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach(string subdirectory in subdirectoryEntries) {
                ProcessDirectory(subdirectory);
            }
        }

        private static void GetInfo() {
            DateTime? date = null;

            for(formInfoIndex = 0; formInfoIndex < formInfo.Length;) {
                date = GetDate();
                Console.WriteLine(date);
            }
        }

        private static DateTime? GetDate() {
            DateTime? date = null;
            String? dateAsString = null;

            while(date == null) {
#if CONSOLE_INPUT
                formInfoIndex = formInfo.Length;
                Console.Write("Enter a date: ");
                dateAsString = Console.ReadLine();
#else
                dateAsString = formInfo[formInfoIndex++].dateAsString;
#endif
                Console.WriteLine("Date as String: {0}", dateAsString);
                try {
                    if(dateAsString != null)
                        date = DateTime.Parse(dateAsString);
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Please enter a valid date.");
                }
            }

            return date;
        }
    }
}
