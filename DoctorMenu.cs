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
                    showPatientList();
                    break;
                case 4:
                    checkPatientDetails();
                    break;
                case 5:
                    showDoctorDetail(loginUser);
                    break;
                case 6:
                    loginMenu.displayLoginMenu(null);
                    break;
                case 7:
                    exit();
                    break;
            }

        }

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





        public void showPatientList()
        {

            Console.Clear();
            showPage("All patients");
            Console.Write("All Patients registered to the DOTNET Hopital Management System");
            Console.SetCursorPosition(0, 8);
            makePatientcolumn();
            makePatientrow(users);

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
        public void checkPatientDetails()
        {
            Console.Clear();
            showPage("Patients Detail");
            Console.Write("Please enter the ID of the patient who's details you are checking. Or press a button to menu");
            Console.SetCursorPosition(0, 8);

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

    }
}