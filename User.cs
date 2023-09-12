using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    internal class User
    {
        public enum UserType
        {
            admin = 0,
            patient,
            doctor
        }

        private string id;
        private string password;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string streetNumber;
        private string street;
        private string city;
        private string state;

        private int usertype;

        private string doctor;


        public User(string id, string password, string firstName, string lastName, string email, string phone, string streetNumber, string street, string city, string state, int usertype, string doctor = null)
        {
            this.id = id;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
            this.streetNumber = streetNumber;
            this.street = street;
            this.city = city;
            this.state = state;
            //enum 
            // 0 = admin,  1 = patient, 2 = doctor
            this.usertype = usertype;
            this.doctor = doctor;
        }


        public string Id { get { return id; } set { this.id = value; } }
        public string Password { set { this.password = value; } }

        public string FirstName { get { return firstName; } set { this.firstName = value; } }
        public string LastName { get { return lastName; } set { this.lastName = value; } }
        public string Email { get { return email; } set { this.email = value; } }
        public string Phone { get { return phone; } set { this.phone = value; } }
        public string StreetNumber { get { return streetNumber; } set { this.streetNumber = value; } }
        public string Street { get { return street; } set { this.street = value; } }
        public string City { get { return city; } set { this.city = value; } }
        public string State { get { return state; } set { this.state = value; } }



        public int Usertype { get { return usertype; } set { this.usertype = value; } }

        public string Doctor { get { return doctor; } set { this.doctor = value; } }

        public bool vaildateUser(string id, string password)
        {
            return this.id.Equals(id) && this.password.Equals(password);
        }


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
                int usertype = int.Parse(userInfo[10]);
                string doctor = userInfo[11];

                User user = new User(id, password, firstName, lastName, email, phone, streetNumber, street, city, state, usertype, doctor);
                users.Add(user);
            }
            return users;
        }



    }
}
