using System;
using System.Collections.Generic;
using System.Text;

namespace WebsiteEmulatorLibrary
{
    public abstract class Account : IAccount
    {
        private int _id;
        private string _email;
        private string _password;
        private string _name;
        private static int _counter = 0;
        internal List<int> userNewsID { get; private set; } = null;
        
        
        public Account(string name, string email, string password)
        {
            _email = email;
            _password = password;
            _name = name;
            _id = _counter;
            _counter++;
            userNewsID = new List<int> {};
        }

        public bool CheckPassword(string password)
        {
            if (password == _password) return true;
            else return false;
        }

        public bool NickCheck(string nickname)
        {
            if (nickname == _name) return true;
            else return false;
        }

        public int ID
        {
            get { return (_id); }
        }

        public bool EmailCheck(string email)
        {
            if (_email == email) return true;
            else return false;
        }

        public void AddNewsID(int ID)
        {
            userNewsID.Add(ID);
        }

        internal virtual bool PermissionCheck(int newsID)
        {
            foreach(int id in userNewsID)
            {
                if (newsID == id) return true;
            }
            return false;
        }
    }
}
