using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    internal class PatientMenu : Menu
    {
        public LoginMenu loginMenu;
        public User loginUser;
        public List<User> users = getUsers();

        public PatientMenu(LoginMenu loginMenu) {
            this.loginMenu = loginMenu;
        }

        public void showPatientMenu()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("|  WELCOME TO PATIENT SYSTEM  |");
            Console.WriteLine("|════════════════════════════════════|");
        }
    }
}
