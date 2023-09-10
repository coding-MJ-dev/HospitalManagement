using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    internal class PatientMenu
    {
        public PatientMenu(User user) { }

        public void showPatientMenu()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("|  WELCOME TO PATIENT SYSTEM  |");
            Console.WriteLine("|════════════════════════════════════|");
        }
    }
}
