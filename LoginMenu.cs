using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HospitalManagement.User;

namespace HospitalManagement
{

    internal class LoginMenu : Menu
    {
        public User loginUser = null;
        public AdminMenu adminMenu = null;
        public DoctorMenu doctorMenu = null;
        public PatientMenu patientMenu = null;
        public List<User> users = new List<User>();

        public LoginMenu(List<User> users) {
            adminMenu = new AdminMenu(this);
            doctorMenu = new DoctorMenu(this);
            patientMenu = new PatientMenu(this);
            this.users = users;
            
        }

        //Display login main menu
        public void displayLoginMenu(string id)
        {
            Console.Clear();
            showPage("Login");
            loginUser = null;
            Console.WriteLine("ID:                                   ");
            Console.WriteLine("Password:                             ");

            string userId = id;
            string password = null;
            if (userId == null)
            {
                Console.SetCursorPosition(3, 5);
                userId = Console.ReadLine();
                password = checkPassword();
            }
            else
            {
                userId = id;
                Console.SetCursorPosition(3, 5);
                Console.WriteLine("{0}", userId);
                password = checkPassword();
            }

            login(userId, password);

        }


        // chcecking password function
        private string checkPassword()
        {
            string password = null;
            Console.SetCursorPosition(9, 6);
            while (true)
            {
                ConsoleKeyInfo click = Console.ReadKey(true);
                if (click.Key != ConsoleKey.Enter)
                {
                    if (click.Key != ConsoleKey.Backspace)
                    {
                        password += click.KeyChar.ToString();
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    Console.WriteLine();
                    break;
                }
            }
            return password;
        }

        //login function
        public void login(string userId, string userPassword)
        {
            foreach (User user in users)
            {
                if (user.Id == userId)
                {
                    //Base on loginUserType send the user different menu
                    if (user.vaildateUser(userId, userPassword))
                    {
                        Console.WriteLine("\n\nValid Credentials");
                        loginUser = user;
                        int loginUserType = user.Usertype;
                        if (loginUserType == 0)
                            adminMenu.showAdminMenu(loginUser);
                        else if (loginUserType == 1)
                            patientMenu.showPatientMenu(loginUser);
                        else if (loginUserType == 2)
                            doctorMenu.showDoctorMenu(loginUser);
                        else
                        {
                            
                            while (true)
                            {

                                ConsoleKeyInfo cki;
                                Console.WriteLine();
                                Console.WriteLine("\n\nPlease check the name and password");
                                cki = Console.ReadKey();
                                if (cki.Key == ConsoleKey.Escape)
                                    Console.Clear();
                                displayLoginMenu(null);
                            }
                        }
                    }
                    else
                    {
                        while (true)
                        {

                            ConsoleKeyInfo cki;
                            Console.WriteLine();
                            Console.WriteLine("\n\nPlease check the name and password");
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Escape)
                                Console.Clear();
                            displayLoginMenu(null);
                        }
                    }
                }
            }
        }



    }   

}
