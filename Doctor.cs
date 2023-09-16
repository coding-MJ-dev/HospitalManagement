using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement;



namespace HospitalManagement
{
    internal class Doctor : User
    {
        public bool isDoctor = true;

        public Doctor(string id, string password, string firstName, string lastName, string email, string phone, string streetNumber, string street, string city, string state, int usertype, string doctor = null) : base(id, password, firstName, lastName, email, phone, streetNumber, street, city, state, usertype, doctor)
        {
            this.isDoctor = true;
        }
    }
}
