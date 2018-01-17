using System;

namespace _draft_3_70
{
    class DepositAccount : BankAccount, I1
    {
        public DepositAccount(string ownerName, double currBal) : base(ownerName, currBal)
        {
        }
        //method to calculate an interest rate amount depending on a curent balance)
        public double interestRate(int duration)
        {
            return (CurrBalance * duration * 0.043); //'0.043' - arbitrariluy set 'interest rate percentage' value
        }
        //method to calculate a new balance ('current balance + %' amount)
        public double accruedAmount(int duration)
        {
            return (CurrBalance + (CurrBalance * duration * 0.043));
        }
    }
}
