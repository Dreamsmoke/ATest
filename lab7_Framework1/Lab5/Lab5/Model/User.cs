using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model
{
    public class User
    {
        private string username;
        private string password;

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public string getUsername() { return username; }
        public void setUsername(string username)
        {
            this.username = username;
        }
        public string getPassword() { return password; }
        public void setPassword(string password)
        {
            this.password = password;
        }
    }

}
