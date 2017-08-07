using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public class Bank
    {
        List<Account> Accounts;
        public Account LoggedInAccount
        {
            get;
            private set;
        }

        public Bank()
        {
            Accounts = new List<Account>();
            LoggedInAccount = null;
        }

        public void CreateAccount(string name)
        {
            Account newAccount = new Account(name, 0);
            Accounts.Add(newAccount);
        }

        public void Login(string name)
        {
            Account acc = Accounts.FirstOrDefault(c => c.Name == name);

            //In theory this would involve some sort of crypto and passwords, but that feels outside of scope for a small code sample :P

            if (acc != null)
            {
                LoggedInAccount = acc;
            }
            else
            {
                throw new Exception("Account doesn't exist.");
            }
        }

        public void Logout()
        {
            LoggedInAccount = null;
        }
    }
}
