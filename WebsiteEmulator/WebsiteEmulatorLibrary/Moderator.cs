using System;
using System.Collections.Generic;
using System.Text;

namespace WebsiteEmulatorLibrary
{
    class Moderator : Account
    {
        public Moderator(string name, string email, string password)
            : base(name, email, password) { }

        internal override bool PermissionCheck(int newsID)
        {
            return true;
        }
    }
}
