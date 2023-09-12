using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    internal class AdminMenu : Menu
    {
        public LoginMenu loginMenu;
        public User loginUser;
        public List<User> users = getUsers();

        public AdminMenu(LoginMenu loginMenu)
        {
            this.loginMenu = loginMenu;
        }




        public void showAdminMenu()
        {
            loginUser = loginMenu.loginUser;
            //string user1 = users[1].Doctor;
            //string userID = loginUser.Id;
            string username = loginUser.FirstName + " " + loginUser.LastName;


            Console.Clear();
            showPage("Administrator Menu");
            Console.Write("Welcome to DONET Hospital Management System: ");
            Console.WriteLine(username);
            Console.WriteLine();
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. List all doctors");
            Console.WriteLine("2. Check doctor details");
            Console.WriteLine("3. List all patients");
            Console.WriteLine("4. Check patient details");
            Console.WriteLine("5. Add doctor");
            Console.WriteLine("6. Add patient");
            Console.WriteLine("7. Logout");
            Console.WriteLine("8. Exit");
            Console.WriteLine();
            Console.WriteLine("Please press number:");
            Console.WriteLine();

            Console.SetCursorPosition(24, 17);
            int number = 0;

            try
            {
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(" \n\n Please enter number from 1 to 8.");
                Console.ReadKey();
                showAdminMenu();
            }

            switch (number)
            {
                case 1:
                    showDoctorList();
                    break;
                case 2:
                    checkDoctorDetails();
                    break;
                case 3:
                    showPatientList();
                    break;
                case 4:
                    checkPatientDetails();
                    break;
                case 5:
                    addDoctor(null, null, null, null, null, null, null, null, null, null, 2, null);
                    break;
                case 6:
                    addPatient(null, null, null, null, null, null, null, null, null, null, 1, "david doctorson");
                    break;
                case 7:
                    loginMenu.displayLoginMenu(null);
                    break;
                case 8:
                    exit();
                    break;
            }
      
        }

        public void showDoctorList() {
            Console.Clear();
            showPage("All Doctors");
            Console.Write("All doctors registered to the DOTNET Hopital Management System");
            Console.SetCursorPosition(0, 8);
            makeDoctortcolumn();
            makeDoctorRow(users);

            Console.WriteLine();
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Clear();
                showAdminMenu();
            }
        }
        public void checkDoctorDetails() {
            Console.Clear();
            showPage("Doctors Detail");
            Console.Write("Please enter the ID of the doctor who's details you are checking. Or press a button to menu");
            Console.SetCursorPosition(0, 8);

            string userId = Console.ReadLine();
            List<User> theDoctor = new List<User>();
            theDoctor = searchDoctor(users, userId);
            Console.SetCursorPosition(0, 8);
            if (theDoctor.Count == 0)
            {
                Console.SetCursorPosition(0, 10);
                Console.Write("Invalid User. Press a button to go back to the main menu.");
                Console.ReadKey();
                Console.Clear();
                showAdminMenu();
            }

            makeDoctortcolumn();
            makeDoctorRow(theDoctor);

            Console.WriteLine();
            Console.ReadKey();
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Clear();
                showAdminMenu();
            }
        }





        public void showPatientList() {

            Console.Clear();
            showPage("All patients");
            Console.Write("All Patients registered to the DOTNET Hopital Management System");
            Console.SetCursorPosition(0, 8);
            makePatientcolumn();
            makePatientrow(users);

            Console.WriteLine();
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Clear();
                showAdminMenu();
            }
        }
        public void checkPatientDetails() {
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
                showAdminMenu();
            }

            makePatientcolumn();
            makePatientrow(theUser);

            Console.WriteLine();
            Console.ReadKey();
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Clear();
                showAdminMenu();
            }
        }
        
        public void addDoctor(string id, string password, string firstName, string lastName, string email, string phone, string streetNumber, string street, string city, string state, int usertype = 2, string doctor = "NULL")
        {
            
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────┐");
            Console.WriteLine("|  DOTNET Hospital Management System |");
            Console.WriteLine("|------------------------------------|");
            Console.WriteLine("|             Add Doctor             |");
            Console.WriteLine("└────────────────────────────────────┘");
            Console.WriteLine("Registering a new doctor with the DOTNET Hopital Management System");
            Console.WriteLine();
            Console.WriteLine("First name:");
            Console.WriteLine("Last name:");
            Console.WriteLine("Email:");
            Console.WriteLine("Phone:");
            Console.WriteLine("Street number:");
            Console.WriteLine("Street:");
            Console.WriteLine("City:");
            Console.WriteLine("State:");
            Console.WriteLine();


            //Auto generate the id and password
            id = getDoctorID();
            password = setPassword();
            doctor = "NULL";



            //Add first name
            if (firstName != null)
            {
                Console.SetCursorPosition(11, 7);
                Console.WriteLine(firstName);
            }
            else
            {
                Console.SetCursorPosition(11, 7);
                firstName = Console.ReadLine();
            }

            //lastname
            if (lastName != null)
            {
                Console.SetCursorPosition(10, 8);
                Console.WriteLine(lastName);
            }
            else
            {
                Console.SetCursorPosition(10, 8);
                lastName = Console.ReadLine();
            }


            //email
            if (email != null)
            {
                Console.SetCursorPosition(6, 9);
                Console.WriteLine(email);
            }           
            else
            {
                Console.SetCursorPosition(6, 9);
                email = Console.ReadLine();
            }

            // phone
            if (phone != null)
            {
                Console.SetCursorPosition(6, 10);
                Console.WriteLine(phone);
            }
            else
            {
                Console.SetCursorPosition(6, 10);
                phone = Console.ReadLine();
            }

            //streetNumber
            if (streetNumber != null)
            {
                Console.SetCursorPosition(14, 11);
                Console.WriteLine(streetNumber);
            }
            else
            {
                Console.SetCursorPosition(14, 11);
                streetNumber = Console.ReadLine();
            }

            //street
            if (street != null)
            {
                Console.SetCursorPosition(7, 12);
                Console.WriteLine(street);
            }
            else
            {
                Console.SetCursorPosition(7, 12);
                street = Console.ReadLine();
            }

            //city
            if (city != null)
            {
                Console.SetCursorPosition(5, 13);
                Console.WriteLine(city);
            }
            else
            {
                Console.SetCursorPosition(5, 13);
                city = Console.ReadLine();
            }

            //state
            Console.SetCursorPosition(6, 14);
            state = Console.ReadLine();
            if (state != null)
            {
                //save the info
                Console.WriteLine("\n\nDo you want to add this user (y/n)?");
                Console.SetCursorPosition(2, 18);
                string select = Console.ReadLine();
                if (select.Equals("y"))
                {
                    string info = (id + ',' + password + ',' + firstName + ',' + lastName + ',' + email + ',' + phone + ',' + streetNumber + ',' + street + ',' + city + ',' + state + ',' + usertype + ',' + doctor);


                    string doctorName = firstName + " " + lastName;
                    Console.Write(doctorName);
                    Console.WriteLine(" added to the System");
                    

                    //System.IO.File.ReadAllLines("userIdDB.txt");

                    using (StreamWriter append = File.AppendText("userIdDB.txt"))
                    {
                        append.WriteLine(info);
                    }
                    users = getUsers();

                    Console.ReadKey();
                    Console.Clear();
                    showAdminMenu();

                }
                else 
                {
                    Console.Clear();
                    showAdminMenu();
                }
            }
            else
            {
                Console.SetCursorPosition(6, 14);
                state = Console.ReadLine();
            }


            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Clear();
                showAdminMenu();
            }




        }
         
        // add new Patient
        public void addPatient(string id, string password, string firstName, string lastName, string email, string phone, string streetNumber, string street, string city, string state, int usertype = 1, string doctor = "david doctorson")
        {

            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────┐");
            Console.WriteLine("|  DOTNET Hospital Management System |");
            Console.WriteLine("|------------------------------------|");
            Console.WriteLine("|             Add Patient            |");
            Console.WriteLine("└────────────────────────────────────┘");
            Console.WriteLine("Registering a new patient with the DOTNET Hopital Management System");
            Console.WriteLine();
            Console.WriteLine("First name:");
            Console.WriteLine("Last name:");
            Console.WriteLine("Email:");
            Console.WriteLine("Phone:");
            Console.WriteLine("Street number:");
            Console.WriteLine("Street:");
            Console.WriteLine("City:");
            Console.WriteLine("State:");
            Console.WriteLine();


            //Auto generate the id and password
            id = getPatientID();
            password = setPassword();
            doctor = "david doctorson";



            //Add first name
            if (firstName != null)
            {
                Console.SetCursorPosition(11, 7);
                Console.WriteLine(firstName);
            }
            else
            {
                Console.SetCursorPosition(11, 7);
                firstName = Console.ReadLine();
            }

            //lastname
            if (lastName != null)
            {
                Console.SetCursorPosition(10, 8);
                Console.WriteLine(lastName);
            }
            else
            {
                Console.SetCursorPosition(10, 8);
                lastName = Console.ReadLine();
            }


            //email
            if (email != null)
            {
                Console.SetCursorPosition(6, 9);
                if (email.Contains('@') && (email.Contains(".")))
                {
                    Console.WriteLine(lastName);
                }
                else
                {
                    Console.WriteLine("\n\nPlease using proper email address");
                    Console.ReadKey();
                    addPatient(firstName, lastName, phone, email, null, null, null, null, null, null, 1, "david doctorson");
                }
            }
            else
            {
                Console.SetCursorPosition(6, 9);
                email = Console.ReadLine();
            }

            // phone
            if (phone != null)
            {
                Console.SetCursorPosition(6, 10);
                Console.WriteLine(phone);
            }
            else
            {
                Console.SetCursorPosition(6, 10);
                phone = Console.ReadLine();
            }

            //streetNumber
            if (streetNumber != null)
            {
                Console.SetCursorPosition(14, 11);
                Console.WriteLine(streetNumber);
            }
            else
            {
                Console.SetCursorPosition(14, 11);
                streetNumber = Console.ReadLine();
            }

            //street
            if (street != null)
            {
                Console.SetCursorPosition(7, 12);
                Console.WriteLine(street);
            }
            else
            {
                Console.SetCursorPosition(7, 12);
                street = Console.ReadLine();
            }

            //city
            if (city != null)
            {
                Console.SetCursorPosition(5, 13);
                Console.WriteLine(city);
            }
            else
            {
                Console.SetCursorPosition(5, 13);
                city = Console.ReadLine();
            }

            //state
            Console.SetCursorPosition(6, 14);
            state = Console.ReadLine();
            if (state != null)
            {
                //save the info
                Console.WriteLine("\n\nDo you want to add this user (y/n)?");
                Console.SetCursorPosition(2, 18);
                string select = Console.ReadLine();
                if (select.Equals("y"))
                {
                    string info = (id + ',' + password + ',' + firstName + ',' + lastName + ',' + email + ',' + phone + ',' + streetNumber + ',' + street + ',' + city + ',' + state + ',' + usertype + ',' + doctor);


                    string name = firstName + " " + lastName;
                    Console.Write(name);
                    Console.WriteLine(" added to the System");


                    //System.IO.File.ReadAllLines("userIdDB.txt");

                    using (StreamWriter append = File.AppendText("userIdDB.txt"))
                    {
                        append.WriteLine(info);
                    }
                    users = getUsers();

                    Console.ReadKey();
                    Console.Clear();
                    showAdminMenu();

                }
                else
                {
                    Console.Clear();
                    showAdminMenu();
                }
            }
            else
            {
                Console.SetCursorPosition(6, 14);
                state = Console.ReadLine();
            }


            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Clear();
                showAdminMenu();
            }

        }

        public void exit()
        {
            Environment.Exit(0);
        }
        




        // Fuctions
        public string getDoctorID()
        {
            int lastDocID = 0;
            //find the last doctorID
            foreach (User user in users)
            {
                var position = user.Usertype;
                if (position == 2) {
                    if(lastDocID < Convert.ToInt32(user.Id))
                    {
                       lastDocID = Convert.ToInt32(user.Id);
                    }
                }
            }
            return Convert.ToString(lastDocID + 1);
        }
        public string getPatientID()
        {
            int lastDocID = 0;
            //find the last doctorID
            foreach (User user in users)
            {
                var position = user.Usertype;
                if (position == 1)
                {
                    if (lastDocID < Convert.ToInt32(user.Id))
                    {
                        lastDocID = Convert.ToInt32(user.Id);
                    }
                }
            }
            return Convert.ToString(lastDocID + 1);
        }


        public string setPassword()
        {
            string defaultPassword = "0000";
            return defaultPassword;
        }

        // DataTable 
        

        //Get user details
        public static List<User> getUsers()
        {
            List<User> users = new List<User>();
            string[] lines = System.IO.File.ReadAllLines("userIdDB.txt");

            // Split each line using "," as delimiter and print the values as
            // User Name: ------, Passowrd: .... "
            // Hint: use foreach loop
            foreach (string info in lines)
            {
                // Split each line
                string[] userInfo = info.Split(',');
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
                int _usertype = int.Parse(userInfo[10]);
                string doctor = userInfo[11];


                User user = new User(id, password, firstName, lastName, email, phone, streetNumber, street, city, state, _usertype, doctor);
                users.Add(user);
            }
            return users;
        }

        public List<User> searchPatient(List<User> users, string id)
        {
            
            List<User> searchedUser = new List<User>();
            foreach (User user in users)
            {
                if (user.Id == id && user.Usertype == 1)
                {
                    searchedUser.Add(user);
                }
            }

            return searchedUser;
        }

        public List<User> searchDoctor(List<User> users, string id)
        {

            List<User> searchedUser = new List<User>();
            foreach (User user in users)
            {
                if (user.Id == id && user.Usertype == 2)
                {
                    searchedUser.Add(user);
                }
            }

            return searchedUser;
        }


    }
}






