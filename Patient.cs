using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    internal class Patient : User
    {
        public bool isPatient = true;

        public Patient(string id, string password, string firstName, string lastName, string email, string phone, string streetNumber, string street, string city, string state, int usertype, string doctor = null) : base(id, password, firstName, lastName, email, phone, streetNumber, street, city, state, usertype, doctor)
        {
            this.isPatient = true;
        }
    }
}
