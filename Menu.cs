using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalManagement
{
    internal class Menu
    {
        public static int length = 48;
        public  string content {  get; set; }
        public Menu() {
            this.content = content;
        }

        public void showPage(string content)
        {
            string title = "DOTNET Hospital Management System";
            int titlePos = length / 2 - title.Length / 2;
            int contPos = length / 2 - content.Length / 2;
            if (titlePos < 0 ) { titlePos = 0; }
            if (contPos < 0 ) {  contPos = 0; }

            Console.Clear();
            makeLine();
            makeEmptyLine();
            makeLine();
            makeEmptyLine();
            makeLine();
            Console.SetCursorPosition(titlePos, 1);
            Console.Write(title);
            Console.SetCursorPosition(contPos, 3);
            Console.Write(content);
            Console.SetCursorPosition(0, 5);
        }




        public void makePatientcolumn()
        {
            int startptr = 8;
            int column1 = 20;
            int column2 = 40;

            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < column1; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("|");
            }
            for (int i = 0;i < column2; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.SetCursorPosition(0, startptr);
            Console.Write("Name");
            Console.SetCursorPosition(21, startptr);
            Console.Write("Doctor");
            Console.SetCursorPosition(42, startptr);
            Console.Write("Email");
            Console.SetCursorPosition(63, startptr);
            Console.Write("Phone");
            Console.SetCursorPosition(84, startptr);
            Console.Write("Address");
            Console.WriteLine();

            for (int i = 0; i <120; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine();
        }

        public void makePatientrow(List<User> users)
        {
            int startrow = 10;
            int column1 = 20;
            int column2 = 40;

            foreach (User user in users)
            {
                //Find user by using usertype (usertype = 0(admin), 1(patinet), 2(doctor)
                if (user.Usertype == 1)
                {
                    Console.SetCursorPosition(0, startrow);
                    for (int i = 0; i < 4; i++)
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
                    Console.Write(user.FirstName + " " + user.LastName);
                    Console.SetCursorPosition(21, startrow);
                    Console.Write(user.Doctor);
                    Console.SetCursorPosition(42, startrow);
                    Console.Write(user.Email);
                    Console.SetCursorPosition(63, startrow);
                    Console.Write(user.Phone);
                    Console.SetCursorPosition(84, startrow);
                    Console.Write(user.StreetNumber + " " + user.Street + " " + user.City + " " + user.State);
                    Console.WriteLine();
                    Console.SetCursorPosition(0, startrow + 1);
                    for (int i = 0; i < 120; i++)
                    {
                        Console.Write("─");
                    }
                    Console.WriteLine();
                    startrow += 2;
                }
            }
        }


        public void makeDoctortcolumn()
        {
            int startptr = 8;
            int column1 = 20;
            int column2 = 40;

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
            Console.Write("Name");
            Console.SetCursorPosition(21, startptr);
            Console.Write("Email");
            Console.SetCursorPosition(42, startptr);
            Console.Write("Phone");
            Console.SetCursorPosition(63, startptr);
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
            int column1 = 20;
            int column2 = 40;

            foreach (User user in users)
            {
                //Find user by using usertype (usertype = 0(admin), 1(patinet), 2(doctor)
                if (user.Usertype == 2)
                {
                    Console.SetCursorPosition(0, startrow);
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
                    Console.Write(user.FirstName + " " + user.LastName);
                    Console.SetCursorPosition(21, startrow);
                    Console.Write(user.Email);
                    Console.SetCursorPosition(42, startrow);
                    Console.Write(user.Phone);
                    Console.SetCursorPosition(63, startrow);
                    Console.Write(user.StreetNumber + " " + user.Street + " " + user.City + " " + user.State);
                    Console.WriteLine();
                    Console.SetCursorPosition(0, startrow + 1);
                    for (int i = 0; i < 100; i++)
                    {
                        Console.Write("─");
                    }
                    Console.WriteLine();
                    startrow += 2;
                }
            }
        }



        public void makeLine()
        {

            for (int i = 0; i < length; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine();
        }

        public void makeEmptyLine()
        {
            Console.Write("|");
            for (int i = 0; i < length - 2; i++)
            {
                Console.Write(" ");
            }
            Console.Write("|");
            Console.WriteLine();
        }



        //get user data
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

        //get appointment data
        public static List<List<string>> getAppointments()
        {
            List<List<string>> appointments = new List<List<string>>();
            string[] lines = System.IO.File.ReadAllLines("appointmentDB.txt");

            // Split each line using "," as delimiter and print the values as
            // User Name: ------, Passowrd: .... "
            // Hint: use foreach loop
            foreach (string info in lines)
            {
                // Split each line
                string[] userInfo = info.Split(',');
                string doctor = userInfo[0];
                string patient = userInfo[1];
                string description = userInfo[2];

                List<string> appointment = new List<string>();
                appointment.Add(doctor);
                appointment.Add(patient);
                appointment.Add(description);

                appointments.Add(appointment);
            }
            return appointments;
        }



        // Fuctions
        public string getDoctorID(List<User> users)
        {
            int lastDocID = 0;
            //find the last doctorID
            foreach (User user in users)
            {
                var position = user.Usertype;
                if (position == 2)
                {
                    if (lastDocID < Convert.ToInt32(user.Id))
                    {
                        lastDocID = Convert.ToInt32(user.Id);
                    }
                }
            }
            return Convert.ToString(lastDocID + 1);
        }
        public string getPatientID(List<User> users)
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

        public void exit()
        {
            Environment.Exit(0);
        }

    }
}
