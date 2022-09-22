//#define MGH

using System;
using System.IO;

namespace FindForm {
    class Program {
        static void Main() {
#if MGH
            String vol_root_dir = "//Cifs2/voldept$";
            String? pet_volunteer_dir = vol_root_dir + "/.Volunteer Files/Pet Therapy";
#else
            String vol_root_dir = "/Users/jdenisco/Developer/Windows/testroot";
            String? pet_volunteer_root_dir = null;
#endif
            String adult_volunteer_root_dir = vol_root_dir + "/.Volunteer Files/ADULT MEDICAL AND NONMEDICAL";
            String junior_volunteer_root_dir = vol_root_dir + "/.Volunteer Files/JUNIOR MEDICAL AND NONMEDICAL/Active JR Volunteers";

            String path = adult_volunteer_root_dir;

            Console.WriteLine("PATH: '{0}'", path);
            if(File.Exists(path)) {
                ProcessFile(path);
            } else if (Directory.Exists(path)){
                ProcessDirectory(path);

            }
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
    }
}

