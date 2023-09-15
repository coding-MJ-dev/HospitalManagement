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
        public List<List<string>> appointments = getAppointments();


        public PatientMenu(LoginMenu loginMenu) {
            this.loginMenu = loginMenu;
            loginUser = loginMenu.loginUser;
        }

        public void showPatientMenu(User loginUser)
        {
            string username = loginUser.FirstName + " " + loginUser.LastName;

            Console.Clear();
            showPage("Patient Menu");
            Console.WriteLine("Welcome to DONET Hospital Management System: {0}", username);
            Console.WriteLine();
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Check my details");
            Console.WriteLine("2. Check my doctor details");
            Console.WriteLine("3. Check all appointments");
            Console.WriteLine("4. Book an appointments");
            Console.WriteLine("5. Logout");
            Console.WriteLine("6. Exit");
            Console.WriteLine();
            Console.WriteLine("Please press number:");
            Console.WriteLine();

            Console.SetCursorPosition(21, 15);
            int number = 0;
            
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(" \nPlease enter number from 1 to 6.");
                Console.ReadKey();
                showPatientMenu(loginUser);
            }

            switch (number)
            {
                case 1:
                    showPatientDetail(loginUser);
                    break;
                case 2:
                    myDoctorDetails(loginUser);
                    break;
                case 3:
                    showAppointmentList(loginUser);
                    break;
                case 4:
                    makeAppointment(loginUser);
                    break;
                case 5:
                    loginMenu.displayLoginMenu(null);
                    break;
                case 6:
                    exit();
                    break;
            }
            
        }

        public void showPatientDetail(User loginUser)
        {
            this.loginUser = loginUser;
            string username = loginUser.FirstName + " " + loginUser.LastName;
            showPage("My details");
            Console.WriteLine("{0}'s Details", username);
            Console.WriteLine();
            Console.WriteLine("patient ID: {0}", loginUser.Id);
            Console.WriteLine("Full name: {0}", loginUser);
            Console.WriteLine("Address: {0} {1}, {2}, {3}", loginUser.StreetNumber, loginUser.Street, loginUser.City, loginUser.State);
            Console.WriteLine("Email: {0}", loginUser.Email);
            Console.WriteLine("Phone: {0}", loginUser.Phone);

            while (true)
            {
                ConsoleKeyInfo cki;
                Console.WriteLine();
                Console.WriteLine("Press a button to go back to the menu.");
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Escape)
                    Console.Clear();
                showPatientMenu(loginUser);
            }

        }

        public void myDoctorDetails(User loginUser)
        {
            Console.Clear();
            showPage("My Doctors");
            Console.Write("Your doctor:");
            Console.SetCursorPosition(0, 8);
            makeDoctortcolumn();
            makeDoctorRow(users);

            Console.WriteLine();
            while (true)
            {
                ConsoleKeyInfo cki;
                Console.WriteLine();
                Console.WriteLine("Press a button to go back to the menu.");
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Escape)
                    Console.Clear();
                showPatientMenu(loginUser);
            }
        }
    

        public void showAppointmentList(User loginUser)
        {

        }

        public void makeAppointment(User loginUser)
        {

        }

    }
}
