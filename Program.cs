using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{

    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            users = User.getUsers();


            LoginMenu loginMenu = new LoginMenu(users);
            loginMenu.displayLoginMenu(null);

        }


    }
}


        

