using System;

namespace _draft_3_70
{
    class CurrentAccount : BankAccount, I1, I2
    {
        public CurrentAccount(string ownerName, double currBal) : base(ownerName, currBal)
        {
        }
        // method to calculate an interest rate amount depending on a curent balance)
        public double interestRate(int duration)
        {
            return (CurrBalance * duration * 0.043); // '0.043' - arbitrarily set 'interest rate percentage' value
        }
        // method to calculate a new balance ('current balance + %' amount)
        public double accruedAmount(int duration)
        {
            return (CurrBalance + (CurrBalance * duration * 0.043));
        }
        // method to withdraw money from the account
        public void currBalSubstract(double changeAmount)
        {
            CurrBalance -= changeAmount;
            Console.Write("\nWithdrawal transaction performed successfuly !\nCurrent balance: {0}", CurrBalance);
        }
        // method to put money to the account
        public void currBalAddition(double changeAmount)
        {
            CurrBalance += changeAmount;
            Console.Write("\nIncome transaction performed successfuly !\nCurrent balance: {0}", CurrBalance);
        }
    }
}
