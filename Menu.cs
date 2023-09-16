using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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

        // head banner
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



        // making patient type table - header
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
        // making patient type table - content
        public void makePatientrow(List<User> users)
        {
            int startrow = 10;
            int column1 = 20;
            int column2 = 40;

            foreach (User user in users)
            {
                // find the patient based on user type
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


        // making doctor type table - header
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

        // making doctor type table - content
        public void makeDoctorRow(List<User> users)
        {
            int startrow = 10;
            int column1 = 20;
            int column2 = 40;

            foreach (User user in users)
            {
                // find the doctor based on user type
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


        // making console line
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


            foreach (string info in lines)
            {
                // Split each line using "," as delimiter and print the values
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
        public static List<string[]> getAppointments()
        {
            List<string[]> appointments = new List<string[]>();
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

                string[] appointment = new string[3];
                appointment[0] = doctor;
                appointment[1] = patient;
                appointment[2] = description;

                appointments.Add(appointment);
            }
            return appointments;
        }


        // get a doctor ID based on user type
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

        // get a patient ID
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

        //setting a default password
        public string setPassword()
        {
            string defaultPassword = "0000";
            return defaultPassword;
        }

        //search a patient based on userID
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

        //search a doctor based on userID
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


        // get all doctor information from userlist
        public List<User> searchAllDoctor(List<User> users)
        {

            List<User> searchedUser = new List<User>();
            foreach (User user in users)
            {
                if (user.Usertype == 2)
                {
                    searchedUser.Add(user);
                }
            }

            return searchedUser;
        }


        // get a specific doc information based on the loginUser
        public List<User> getMyDoctor(User loginUser)
        {
            List<User> myDocotors = new List<User>();
            User myDoctor;
            List<User> users = getUsers();
            //find the last doctorID
            foreach (User user in users)
            {
                if (loginUser.Doctor == (user.FirstName + " " + user.LastName))
                {
                    myDoctor = user;
                    myDocotors.Add(myDoctor);
                }
            }
            return myDocotors;
        }

        // get a specific patient's appointment
        public List<string[]> getThePatientAppointment(User loginUser)
        {
            List<string[]> appointments = getAppointments();
            List<string[]> myAppointment = new List<string[]>();
            string doc;
            string patient;
            string desc;
            string username = loginUser.FirstName + " " + loginUser.LastName;


            //find the login user's appoinment
            foreach (string[] apponitment in appointments)
            {
                if (username == apponitment[1])
                {
                    doc = apponitment[0];
                    patient = apponitment[1];
                    desc = apponitment[2];
                    myAppointment.Add(apponitment);
                }
            }
            return myAppointment;
        }

        // get a specific doctor's appointment
        public List<string[]> getTheDoctorsAppointment(User loginUser)
        {
            List<string[]> appointments = getAppointments();
            List<string[]> myAppointment = new List<string[]>();
            string doc;
            string patient;
            string desc;
            string username = loginUser.FirstName + " " + loginUser.LastName;


            //find the login user's appoinment
            foreach (string[] apponitment in appointments)
            {
                if (username == apponitment[0])
                {
                    doc = apponitment[0];
                    patient = apponitment[1];
                    desc = apponitment[2];
                    myAppointment.Add(apponitment);
                }
            }
            return myAppointment;
        }



        // creat appointment table - header
        public void makeAppointmentcolumn()
        {
            int startptr = 8;
            int column1 = 30;
            int column2 = 50;

            for (int i = 0; i < 2; i++)
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
            Console.Write("Doctor");
            Console.SetCursorPosition(31, startptr);
            Console.Write("Patient");
            Console.SetCursorPosition(62, startptr);
            Console.Write("Description");
            Console.WriteLine();

            for (int i = 0; i < 100; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine();
        }

        // creat appointment table - content
        public void makeAppointmentRow(List<string[]> appointments)
        {
            int startrow = 10;
            int column1 = 30;
            int column2 = 50;

            foreach (var appointment in appointments)
            {
                Console.SetCursorPosition(0, startrow);
                for (int i = 0; i < 2; i++)
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
                Console.Write(appointment[0]);
                Console.SetCursorPosition(31, startrow);
                Console.Write(appointment[1]);
                Console.SetCursorPosition(62, startrow);
                Console.Write(appointment[2]);
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

        //exit option
        public void exit()
        {
            Environment.Exit(0);
        }



    }
}
