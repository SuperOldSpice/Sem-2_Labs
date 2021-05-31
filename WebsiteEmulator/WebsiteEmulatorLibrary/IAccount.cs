using System;
using System.Collections.Generic;
using System.Text;

namespace WebsiteEmulatorLibrary
{
    interface IAccount
    {
        public bool EmailCheck(string email);
        public bool CheckPassword(string password);
        public bool NickCheck(string nickname);
        public void AddNewsID(int ID);
    }
}
