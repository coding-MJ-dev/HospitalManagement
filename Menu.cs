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
    }
}
