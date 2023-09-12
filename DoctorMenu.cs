using HospitalManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalManagement
{
    internal class DoctorMenu
    {
        public DoctorMenu(User user) { }

        public void showDoctorMenu()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("|  WELCOME TO DOCTOR SYSTEM  |");
            Console.WriteLine("|════════════════════════════════════|");
        }
    }
}
