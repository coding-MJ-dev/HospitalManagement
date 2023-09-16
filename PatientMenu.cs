using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HospitalManagement.User;

namespace HospitalManagement
{
    internal class PatientMenu : Menu
    {
        public LoginMenu loginMenu;
        public User loginUser;
        public List<User> users = getUsers();
        //public List<string[]> appointments = getAppointments();


        public PatientMenu(LoginMenu loginMenu)
        {
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
            Console.Clear();
            string username = loginUser.FirstName + " " + loginUser.LastName;
            showPage("My details");
            Console.WriteLine("{0}'s Details", username);
            Console.WriteLine();
            Console.WriteLine("patient ID: {0}", loginUser.Id);
            Console.WriteLine("Full name: {0}", username);
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
            showPage("My Doctor");
            Console.Write("Your doctor:");
            Console.SetCursorPosition(0, 8);
            makeDoctortcolumn();

            List<User> myDocotors = getMyDoctor(loginUser);
            makeDoctorRow(myDocotors);

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
            Console.Clear();
            showPage("My Appointment");
            string username = loginUser.FirstName + " " + loginUser.LastName;
            Console.WriteLine("Appoint for {0}", username);
            Console.SetCursorPosition(0, 8);
            getAppointments();
            var appointments = getThePatientAppointment(loginUser);
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
                showPatientMenu(loginUser);
            }

        }

        public void makeAppointment(User loginUser)
        {
            Console.Clear();
            showPage("Book Appointment");
            string description;


            if (loginUser.Doctor == "0")
            {
                Console.WriteLine("You are not registered with any doctor! please choose which doctor you would like to register with.");
                User mydoc;
                var doclist = searchAllDoctor(users);
                int docNumber = doclist.Count;
                int num = 0;
                showDoctorList();
                Console.WriteLine();
                Console.SetCursorPosition(0, 7);
                Console.Write("Please press number:");
                try
                {
                    Console.SetCursorPosition(22, 7);
                    num = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(" \nInvalid doctor number");
                    Console.ReadKey();
                    showPatientMenu(loginUser);
                }

                if (num <= docNumber)
                {

                    mydoc = doclist[num - 1];

                    loginUser.Doctor = (mydoc.FirstName + " " + mydoc.LastName);
                    editDocInfo(loginUser, loginUser.Doctor);
                }
                else
                {
                    Console.WriteLine(" \nInvalid doctor number");
                    Console.ReadKey();
                    showPatientMenu(loginUser);
                }
            }

            Console.Clear();
            showPage("Book Appointment");
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("You are booking a new appointment with {0}", loginUser.Doctor);
            Console.WriteLine("Description of the appointment: ");
            Console.SetCursorPosition(0, 8);
            description = Console.ReadLine();
            addAppointmentDescription(loginUser, description);

            Console.WriteLine("The appointment has been booked successfully");


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

        public void showDoctorList()
        {
            Console.SetCursorPosition(0, 8);
            makeDoctortcolumn();
            makeDoctorRow(users);
            Console.WriteLine();
        }


        public void makeDoctortcolumn()
        {
            int startptr = 8;
            int column0 = 4;
            int column1 = 20;
            int column2 = 40;

            for (int j = 0; j < column0; j++)
            {
                Console.Write(" ");
            }
            Console.Write("|");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < column1; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("|");
            }
            for (int i = 0; i < column2; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.SetCursorPosition(0, startptr);
            Console.Write(" ");
            Console.SetCursorPosition(4, startptr);
            Console.Write("Name");
            Console.SetCursorPosition(25, startptr);
            Console.Write("Email");
            Console.SetCursorPosition(46, startptr);
            Console.Write("Phone");
            Console.SetCursorPosition(67, startptr);
            Console.Write("Address");
            Console.WriteLine();

            for (int i = 0; i < 100; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine();
        }
        public void makeDoctorRow(List<User> users)
        {
            int startrow = 10;
            int column0 = 4;
            int column1 = 20;
            int column2 = 40;
            int num = 1;

            foreach (User user in users)
            {
                if (user.Usertype == 2)
                {
                    Console.SetCursorPosition(0, startrow);
                    for (int j = 0; j < column0; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("|");
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < column1; j++)
                        {
                            Console.Write(" ");
                        }
                        Console.Write("|");
                    }
                    for (int i = 0; i < column2; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(0, startrow);
                    Console.Write(num);
                    Console.SetCursorPosition(4, startrow);
                    Console.Write(user.FirstName + " " + user.LastName);
                    Console.SetCursorPosition(25, startrow);
                    Console.Write(user.Email);
                    Console.SetCursorPosition(46, startrow);
                    Console.Write(user.Phone);
                    Console.SetCursorPosition(67, startrow);
                    Console.Write(user.StreetNumber + " " + user.Street + " " + user.City + " " + user.State);
                    Console.WriteLine();
                    Console.SetCursorPosition(0, startrow + 1);
                    for (int i = 0; i < 100; i++)
                    {
                        Console.Write("─");
                    }
                    Console.WriteLine();
                    num++;
                    startrow += 2;
                }
            }
        }

        public void editDocInfo(User loginUser, string docName)
        {


            string[] lines = File.ReadAllLines("userIdDB.txt");
            // Split each line using "," as delimiter and print the values as
            // User Name: ------, Passowrd: .... "
            // Hint: use foreach loop
            int count = 0;
            foreach (string info in lines)
            {
                // Split each line
                string[] userInfo = info.Split(',');

                if (userInfo[0] == loginUser.Id)
                {
                    string id = userInfo[0];
                    string password = userInfo[1];
                    string firstName = userInfo[2];
                    string lastName = userInfo[3];
                    string email = userInfo[4];
                    string phone = userInfo[5];
                    string streetNumber = userInfo[6];
                    string street = userInfo[7];
                    string city = userInfo[8];
                    string state = userInfo[9];
                    int usertype = int.Parse(userInfo[10]);
                    string doctor = docName;

                    string newinfo = (id + ',' + password + ',' + firstName + ',' + lastName + ',' + email + ',' + phone + ',' + streetNumber + ',' + street + ',' + city + ',' + state + ',' + usertype + ',' + doctor);

                    lineChanger(newinfo, "userIdDB.txt", count);
                }
                else
                {
                    count++;
                }

            }
            

            static void lineChanger(string newText, string fileName, int line_to_edit)
            {
                string[] arrLine = File.ReadAllLines(fileName);
                arrLine[line_to_edit] = newText;
                File.WriteAllLines(fileName, arrLine);
            }

        }

        public void addAppointmentDescription(User loginUser, string appointmentDescription)
        {
            string doc = loginUser.Doctor;
            string username = loginUser.FirstName + " " + loginUser.LastName;
            string desc = appointmentDescription;
            string info = (doc + "," + username + "," + desc);
            using (StreamWriter append = File.AppendText("appointmentDB.txt"))
            {
                append.Write(info);
                append.Flush();
                append.Close();
            }


        }
    }
}
