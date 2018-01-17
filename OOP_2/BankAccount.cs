using System;

namespace _draft_3_70
{
    public class BankAccount
    {
        //fields of the class
        static int id;
        int accId;
        string owner;
        double currBalance;
        //constructor
        public BankAccount(string ownerName, double currBal)
        {
            id++;
            accId = id;
            Owner = ownerName;
            CurrBalance = currBal;
        }
        // Current balance property
        public double CurrBalance
        {
            get { return currBalance; }
            set { currBalance = value; }
        }
        //Account's owner property
        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        //method to close the account (withdraw the whole available amount of the current balance and sets one to zero)
        public void accClose()
        {
            char userChoice = ' ';
            do
            {
                Console.Write("\nTo perform or discard withdrawal operation press 'y' or 'n' key respectively: ");
                userChoice = Char.ToLower(Console.ReadKey().KeyChar);
                if (userChoice.Equals('y'))
                {
                    CurrBalance = 0;
                    Console.Write("\n\nWithdrawal operation was performed successfully.\nCurrent balance of the account: {0}\n", CurrBalance);
                    break;
                }
                else if (userChoice.Equals('n'))
                {
                    Console.Write("\n\nWithdrawal operation wasn't performed.\nCurrent balance of the account: {0}\n", CurrBalance);
                    break;
                }
                else
                    Console.Write("\n\nIncorrect choice.\nWithdrawal operation wasn't performed.\nCurrent balance of the account: {0}\n", CurrBalance);
            } while (!userChoice.Equals('y') | !userChoice.Equals('n'));
        }
        //property to show an account's id
        public int GetId
        {
            get { return accId; }
        }
    }
}