﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Data.Testing
{
    /// <summary>
    /// wrapper for a standard "person" with
    /// email , network account , password etc
    /// </summary>

    public class NameInfo
    {
        protected NameInfo()
        {
        }

        public NameInfo(string firstName, string lastName, string emailDomain, string adDomain)
        {
            CN = firstName + " " + lastName;
            GivenName = firstName;
            SurName = lastName;
            sAMAccountName = firstName.Substring(0, 1).ToLower() + lastName.ToLower();
            DisplayName = lastName + ", " + firstName;
            UserPrincipalName = (lastName + "." + firstName + adDomain).ToLower();
            Email = (firstName + "." + lastName + emailDomain).ToLower();
            RandomPassword = Demo.Data.Testing.RandomPassword.Generate(false);
        }

        public string CN { get; private set; }
        public string sAMAccountName { get; private set; }
        public string Email { get; set; }
        public string GivenName { get; private set; }
        public string SurName { get; private set; }
        public string DisplayName { get; private set; }
        public string UserPrincipalName { get; private set; }
        public string RandomPassword { get; private set; }

    }
}
