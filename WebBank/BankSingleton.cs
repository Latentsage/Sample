using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Banking;

namespace WebBank
{
    public static class BankSingleton
    {
        //There is technically an issue here, where the bank exists only in cache, but the user accounts are in a local sql db.
        //To be correct, we'd populate the bank from those accounts, but I think that's out of scope for the model.
        //Will create problems if you try to login to an account after the server loses cache, since it will exist in the db but not the bank.
        public static Bank GetBank()
        {
            var session = System.Web.HttpContext.Current.Session;

            if (session["Bank"] == null)
            {
                session["Bank"] = new Bank();
            }

            return session["Bank"] as Bank;
        }
    }
}