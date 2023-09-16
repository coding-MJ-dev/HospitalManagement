using HospitalManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalManagement
{
    internal class DoctorMenu : Menu
    {
        public LoginMenu loginMenu;
        public User loginUser;
        public List<User> users = getUsers();

        public DoctorMenu(LoginMenu loginMenu) {
            this.loginMenu = loginMenu;
            loginUser = loginMenu.loginUser;
        }

        //main doctor menu
        public void showDoctorMenu(User loginUser)
        {
            string username = loginUser.FirstName + " " + loginUser.LastName;

            Console.Clear();
            showPage("Doctor Menu");
            Console.Write("Welcome to DONET Hospital Management System: ");
            Console.WriteLine(username);
            Console.WriteLine();
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. List doctor detail");
            Console.WriteLine("2. List patients");
            Console.WriteLine("3. List appointments");
            Console.WriteLine("4. check particular patient");
            Console.WriteLine("5. List appointment with patient");
            Console.WriteLine("6. Logout");
            Console.WriteLine("7. Exit");
            Console.WriteLine();
            Console.WriteLine("Please press number:");
            Console.WriteLine();

            Console.SetCursorPosition(21, 16);
            int number = 0;

            try
            {
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(" \nPlease enter number from 1 to 7.");
                Console.ReadKey();
                showDoctorMenu(loginUser);
            }

            switch (number)
            {
                case 1:
                    showDoctorDetail(loginUser);
                    break;
                case 2:
                    showPatientList(loginUser);
                    break;
                case 3:
                    showAppointmentList(loginUser);
                    break;
                case 4:
                    checkPatientDetails(loginUser);
                    break;
                case 5:
                    showAppointmentWithAPatient(loginUser);
                    break;
                case 6:
                    loginMenu.displayLoginMenu(null);
                    break;
                case 7:
                    exit();
                    break;
            }

        }

        //display the login users detail
        public void showDoctorDetail(User loginUser)
        {
            Console.Clear();
            string username = loginUser.FirstName + " " + loginUser.LastName;
            showPage("My details");
            Console.WriteLine("{0}'s Details", username);
            Console.WriteLine();
            Console.SetCursorPosition(0, 8);

            List<User> myself = new List<User>();
            myself.Add(loginUser);
            makeDoctortcolumn();
            makeDoctorRow(myself);


            while (true)
            {
                ConsoleKeyInfo cki;
                Console.WriteLine();
                Console.WriteLine("Press a button to go back to the menu.");
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Escape)
                    Console.Clear();
                showDoctorMenu(loginUser);
            }
        }

        //user login user's patient detail
        public void showPatientList(User loginUser)
        {
            Console.Clear();
            string username = loginUser.FirstName + " " + loginUser.LastName;
            showPage("My Patients");
            Console.Write("Patients assigned to {0}:", username);
            Console.SetCursorPosition(0, 8);

            List<User> myPatients = new List<User>();
            foreach (var user in users)
            {
                if (user.Doctor == username)
                {
                    myPatients.Add(user);
                }
            }

            makePatientcolumn();
            makePatientrow(myPatients);

            Console.WriteLine();
            while (true)
            {
                ConsoleKeyInfo cki;
                Console.WriteLine();
                Console.WriteLine("Press a button to go back to the menu.");
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Escape)
                    Console.Clear();
                showDoctorMenu(loginUser);
            }
        }

        // show login user's appotintment
        public void showAppointmentList(User loginUser)
        {
            Console.Clear();
            showPage("All Appointments");
            string username = loginUser.FirstName + " " + loginUser.LastName;
            Console.WriteLine("Appoint for {0}", username);
            Console.SetCursorPosition(0, 8);
            getAppointments();
            var appointments = getTheDoctorsAppointment(loginUser);
            makeAppointmentcolumn();
            makeAppointmentRow(appointments);
            Console.WriteLine();

            while (true)
            {
                ConsoleKeyInfo cki;
                Console.WriteLine();
                Console.WriteLine("Press a button to go back to the menu.");
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Escape)
                    Console.Clear();
                showDoctorMenu(loginUser);
            }

        }

        // search a specific patient data
        public void checkPatientDetails(User loginUser)
        {
            Console.Clear();
            showPage("Check Patients Detail");
            Console.Write("Enter the ID of the patient to check: ");
            Console.SetCursorPosition(0, 8);

            //find a patient by using patient data
            users = getUsers();
            string userId = Console.ReadLine();
            List<User> theUser = new List<User>();
            theUser = searchPatient(users, userId);
            Console.SetCursorPosition(0, 8);
            if (theUser.Count == 0)
            {
                Console.SetCursorPosition(0, 10);
                Console.Write("Invalid User. Press a button to go back to the main menu.");
                Console.ReadKey();
                Console.Clear();
                showDoctorMenu(loginUser);
            }

            makePatientcolumn();
            makePatientrow(theUser);

            while (true)
            {
                ConsoleKeyInfo cki;
                Console.WriteLine();
                Console.WriteLine("Press a button to go back to the menu.");
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Escape)
                    Console.Clear();
                showDoctorMenu(loginUser);
            }
        }

        // show the a specific patient appointment data allocated to logined doctor
        public void showAppointmentWithAPatient(User loginUser)
        {
            Console.Clear();
            showPage("Appointments with");
            string username = loginUser.FirstName + " " + loginUser.LastName;
            Console.Write("Enter the ID of the patient you would like to view appointments for: ");
            Console.SetCursorPosition(0, 7);
            string userId = Console.ReadLine();
            List<User> thePatient = new List<User>();
            thePatient = searchPatient(users, userId);
            if (thePatient.Count == 0)
            {
                Console.SetCursorPosition(0, 10);
                Console.Write("No booking or Invalid patient. Press a button to go back to the main menu.");
                Console.ReadKey();
                Console.Clear();
                showDoctorMenu(loginUser);
            }

            
            var appointments = getThePatientAppointment(thePatient[0]);


            makeAppointmentcolumn();
            makeAppointmentRow(appointments);
            Console.WriteLine();

            while (true)
            {
                ConsoleKeyInfo cki;
                Console.WriteLine();
                Console.WriteLine("Press a button to go back to the menu.");
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Escape)
                    Console.Clear();
                showDoctorMenu(loginUser);
            }

        }
    }
}