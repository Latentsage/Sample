using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public class Account
    {
        public Queue<double> Transactions;

        public string Name
        {
            get;
            private set;
        }

        public double Balance
        {
            get
            {
                //Aggregate transactions. At each step, check for an invalid withdrawal. Throw if so. Probably unnecessary, due to checks in Withdraw, but doesn't hurt to have for future cases
                double ret = Transactions.Aggregate((a, b) => ((a < 0) || (a + b < 0)) ? -1 : a + b);

                if (ret < 0)
                {
                    throw new Exception();
                }

                return ret;
            }
        }

        public Account(string name, double startingBalance)
        {
            Name = name;
            Transactions = new Queue<double>();
            Transactions.Enqueue(startingBalance);
        }

        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new Exception("Can't deposit a negative amount.");
            }
            Transactions.Enqueue(amount);
        }

        public void Withdraw(double amount)
        {
            if (Balance < amount)
            {
                throw new Exception("Insufficient funds");
            }

            if (amount < 0)
            {
                throw new Exception("Can't withdraw a negative amount.");
            }

            Transactions.Enqueue(0 - amount);
        }

    }
}
