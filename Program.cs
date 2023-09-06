using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines("userIdDB.txt");

                // Split each line using "," as delimiter and print the values as
                // User Name: ------, Passowrd: .... "
                // Hint: use foreach loop
                foreach (string set in lines)
                {
                    // Split each line
                    string[] splits = set.Split(',');
                    //Display the values of username and password
                    Console.WriteLine("Patient ID: {0}, Full Name: {1} {2}, Address: {3} {4} {5} {6}, Email: {7}, Phone: {8}", splits[0], splits[1], splits[2], splits[3], splits[4], splits[5], splits[6], splits[7], splits[8]);
                }
                // Ready an key from user                
                Console.ReadKey();
            }
            // Catch the FileNotFoundException exception
            catch (FileNotFoundException e)
            {
                // Display the error message
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

        }
    }
}
