//#define MGH

using System;

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

            Console.WriteLine("Hello, World!");
        }
    }
}

