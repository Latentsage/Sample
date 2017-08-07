using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking;

namespace ConsoleApp
{
    class Commands
    {
        public Bank bank;

        public Commands()
        {
            bank = new Bank();
        }

        public void Create()
        {
            Console.WriteLine("Account Name?");

            string name = Console.ReadLine();

            bank.CreateAccount(name);

            Console.WriteLine("Account created.");
        }

        public void Login()
        {
            if (bank.LoggedInAccount != null)
            {
                throw new Exception("Already logged in");
            }

            Console.WriteLine("Account Name?");

            string name = Console.ReadLine();

            bank.Login(name);

            Console.WriteLine("Welcome {0}", name);
        }

        public void Deposit()
        {
            RequiresLogin();

            Console.WriteLine("Deposit how much?");
            double amount;

            if (double.TryParse(Console.ReadLine(), out amount))
            {
                bank.LoggedInAccount.Deposit(amount);
                Console.WriteLine("Deposited ${0}", amount);
            }
            else
            {
                throw new Exception("Invalid deposit value.");
            }
        }

        public void Withdraw()
        {
            RequiresLogin();

            Console.WriteLine("Withdraw how much?");
            double amount;

            if (double.TryParse(Console.ReadLine(), out amount))
            {
                bank.LoggedInAccount.Withdraw(amount);
                Console.WriteLine("Withdrew ${0}", amount);
            }
            else
            {
                throw new Exception("Invalid withdrawal value.");
            }
        }

        public void Balance()
        {
            RequiresLogin();

            Console.WriteLine("Current account balance for {0} is ${1}.", bank.LoggedInAccount.Name, bank.LoggedInAccount.Balance);
        }

        public void History()
        {
            RequiresLogin();

            Account acc = bank.LoggedInAccount;
            
            Console.WriteLine("Account History for {0}", acc.Name);

            Console.WriteLine("Starting balance: ${0}", acc.Transactions.First());

            foreach (double amount in acc.Transactions.Skip(1))
            {
                //Use abs for amount here since it's more proper grammar
                Console.WriteLine("{0} in the amount of ${1}", amount > 0 ? "Deposit" : "Withdrawal", Math.Abs(amount));
            }
        }

        public void Logout()
        {
            if (bank.LoggedInAccount == null)
            {
                Console.WriteLine("Already logged out.");
            }
            else
            {
                Console.WriteLine("Logging out...");
            }

            bank.Logout();
        }

        public void Help()
        {
            Console.WriteLine("Commands are create|login|deposit|withdraw|balance|history|logout|exit|help");
        }

        void RequiresLogin()
        {
            if (bank.LoggedInAccount == null)
            {
                throw new Exception("This command requires a logged in account");
            }
        }
    }
}
