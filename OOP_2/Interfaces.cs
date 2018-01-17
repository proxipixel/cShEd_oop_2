using System;

namespace _draft_3_70
{
    interface I1
    {
        double interestRate(int duration);
        double accruedAmount(int duration);
    }

    interface I2
    {
        void currBalSubstract(double changeAmount);
        void currBalAddition(double changeAmount);
    }
}
