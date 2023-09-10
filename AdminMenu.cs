using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    internal class AdminMenu
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
            Console.WriteLine("┌────────────────────────────────────┐");
            Console.WriteLine("|  DOTNET Hospital Management System |");
            Console.WriteLine("|------------------------------------|");
            Console.WriteLine("|         Administrator Menu         |");
            Console.WriteLine("└────────────────────────────────────┘");
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
                    //addDoctor(null, null, null, null, null, null, null, null, null, null, 2, null);
                    break;
                case 6:
                    //addPatient(null, null, null, null, null, null, null, null, null, null, 1, "david doctorson");
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
            Console.WriteLine("doctors");
            Console.ReadKey();
        }
        public void checkDoctorDetails() {
        }
        public void showPatientList() {
        }
        public void checkPatientDetails() {
        }
        /*
        public void addDoctor(null, null, null, null, null, null, null, null, null, null, 2, null)
        {



        }
        public void addPatient(null, null, null, null, null, null, null, null, null, null, 1, "david doctorson")
        {

        }
        */
        public void exit()
        {

        }



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
    }
}
