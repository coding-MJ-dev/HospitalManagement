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


        public void makePatientTable()
        {
            int column1 = 20;
            int column2 = 40;

            for (int i = 0; i < column1; i++) {
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
