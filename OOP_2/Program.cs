using System;
using System.Collections.Generic;

namespace _draft_3_70
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BankAccount> accList = new List<BankAccount>();
            I1 I1Acc;
            I2 I2Acc;
            bool isTrue = false;
            double accAmount = 0.0;
            string accOwner = "";
            int userChoice = 0;
            int accId = 0;
            Console.Write("\nThis is your personal Bank Account.\nOne provides you with following specific accounts:\n\n- Deposit account\n- Current account\n- Card account\n");
            Console.Write("\nTo begin manage your funds open a specific account.\n");

            do
            {
                // main menu
                Console.Write("\n\n Bank Account feature list\n\n(Type a preferrable feature's list number and press 'Enter')\n[1] Open a new account\n[2] Manage existing accounts\n[3] Show a status of your Bank Account\n");

                while (!Int32.TryParse(Console.ReadLine(), out userChoice) || userChoice < 1 | userChoice > 3)
                {
                    Console.Write("\nIncorrect option has been selected\nPlease pick any of available ones: ");
                }

                if (accList.Count == 0 && userChoice > 1)
                {
                    Console.Write("\nYou have no active accounts yet.\nSelect appropriate feature to create one.");
                    continue;
                }

                switch (userChoice)
                {
                    case 1: // case to open a new acc
                        Console.Write("\n Specify a type of account you want to create:\n\n(Type a preferrable account's list number and press 'Enter')\n[1] Deposit account\n[2] Current account\n[3] Card account\n");
                        // selection of an acc type
                        while (!Int32.TryParse(Console.ReadLine(), out userChoice) || userChoice < 1 | userChoice > 3)
                        {
                            Console.Write("\nIncorrect option has been selected\nPlease pick any of available ones: ");
                        }
                        // 'owner' & 'money amount' values input
                        Console.Write("\nAdd 'owner name' and 'amount' of your new Deposit account.\nAdd an owner name: ");
                        // 'non-empty owner value input' check
                        while (String.IsNullOrWhiteSpace(accOwner = Console.ReadLine()))
                        {
                            Console.Write("\n'Owner name' field mustn't be empty !\nOwner name: ");
                        }
                        Console.Write("\nOwner name was saved.\nAdd an amount: ");
                        // 'money amount' value input
                        while (!Double.TryParse(Console.ReadLine(), out accAmount) || accAmount < 0)
                        {
                            Console.Write("\nAmount must contain only digits above zero !\nAmount: ");
                        }
                        Console.Write("\nAmount was saved.");

                        // creation of acc according to previously selected type
                        switch (userChoice)
                        {
                            case 1: // case to open a 'Deposit acc'
                                // new account instance intialization using both 'owner' & 'amount' values just added by user
                                accList.Add(new DepositAccount(accOwner, accAmount));
                                Console.Write("\nDeposit account successfully created !");
                                break;

                            // case to open a 'Current acc'
                            case 2:
                                // new account instance intialization using both 'owner' & 'amount' values just added by user
                                accList.Add(new CurrentAccount(accOwner, accAmount));
                                Console.Write("\nCurrent account successfully created !");
                                break;

                            // case to open a 'Card acc'
                            case 3:
                                // new account instance intialization using both 'owner' & 'amount' values just added by user
                                accList.Add(new CardAccount(accOwner, accAmount));
                                Console.Write("\nCard account successfully created !");
                                break;
                        }
                        break;

                    case 2: // case to manage existing acc's
                        do
                        {
                            // 'manage accs' menu                            
                            Console.Write("\n\n Operations with accounts: \n\n(Confirm your choice by pressing 'Enter')\n[1] Show account owner's name\n[2] Show account's current balance amount\n[3] Calculate an interest rate amount\n[4] Show a balance amount including interest rate (Deposit and Card accounts only)\n[5] Put money into an account (Current and Card accounts only)\n[6] Withdraw money from an account (Current and Card accounts only)\n[7] Withdraw all money from an account\n");
                            // 'valid menu item selection' check
                            while (!Int32.TryParse(Console.ReadLine(), out userChoice) || userChoice < 1 | userChoice > 7)
                            {
                                Console.Write("\nIncorrect option has been selected\nPlease pick any of available ones: ");
                            }
                            do
                            {
                                // ID input pass in case if there's only one item in the list
                                if (accList.Count == 1)
                                {
                                    accId = 0;
                                    isTrue = false;
                                    continue;
                                }
                                // selecting an acc to apply the chosen option to
                                Console.Write("\nType an account ID to apply the chosen option to and press 'Enter': ");
                                while (!Int32.TryParse(Console.ReadLine(), out accId) || accId < 1)
                                {
                                    Console.Write("\nAccount ID must contain only digits above zero !\nPlease state a valid account ID: ");
                                }

                                // check availability of entered ID in the list of accs                                
                                foreach (BankAccount anAcc in accList)
                                {
                                    if (anAcc.GetId == accId)
                                    {
                                        accId = accList.IndexOf(anAcc);
                                        isTrue = false;
                                        break;
                                    }
                                    isTrue = true;
                                }
                                if (isTrue)
                                {
                                    Console.Write("\nThere's no account with such ID in your Bank Account !");
                                    continue;
                                }
                            } while (isTrue);
                            if ((!isTrue && ((accList[accId].GetType() == typeof(DepositAccount)) && (userChoice == 5 || userChoice == 6)) || ((accList[accId].GetType() == typeof(CurrentAccount)) && (userChoice == 3 || userChoice == 4))))
                            {
                                Console.Write("\nThis operation is not applicable to accounts of '{0}' type !\nPlease use the 'Operations with accounts' menu to make a valid choice.\n", accList[accId].GetType().Name);
                                isTrue = true;
                                continue;
                            }
                            else if (userChoice == 6 && accList[accId].CurrBalance == 0)
                                Console.Write("\nThere is no money to withdraw in this account !\nCurrent balance: {0}", accList[accId].CurrBalance);
                            else if (userChoice == 5 || userChoice == 6)
                            {
                                do
                                {
                                    Console.Write("\nIndicate an amount: ");
                                    while (!Double.TryParse(Console.ReadLine(), out accAmount))
                                    {
                                        Console.Write("\nAmount must contain only positive numbers !");
                                    }
                                    if (userChoice == 6 && accAmount > accList[accId].CurrBalance)
                                    {
                                        Console.Write("\nWithdrawal transaction unsuccessful !\nAn amount to withdraw can't exceed a current balance of the account.");
                                        isTrue = true;
                                        continue;
                                    }
                                    isTrue = false;
                                    break;

                                } while (isTrue);
                            }
                        } while (isTrue);

                        switch (userChoice)
                        {
                            case 1: // 'Show account owner's name' case
                                Console.Write("\nOwner name: {0}", accList[accId].Owner);
                                break;

                            case 2: // 'Show account's current balance amount' case
                                Console.Write("\nCurrent balance of the account: {0}", accList[accId].CurrBalance);
                                break;

                            case 3: // 'interest rate amount calculation and display' case
                                // declaration of an interface type reference
                                I1Acc = (I1)accList[accId];
                                // 'depositing term' value input; it's one among other values using by 'interest rate amount calculation' method
                                Console.Write("\nSpecify a depositing term (in months): ");
                                while (!Int32.TryParse(Console.ReadLine(), out userChoice) || userChoice < 1)
                                {
                                    Console.Write("\nDepositing term must contain only digits above zero !\nPlease specify a valid term: ");
                                }
                                Console.Write("\nCurrent balance including interest rate amount: {0}", I1Acc.interestRate(userChoice));
                                break;

                            case 4: // 'an acc's current balance including interest rate amount calculation and display' case
                                // declaration of an interface type reference
                                I1Acc = (I1)accList[accId];
                                // 'depositing term' value input; it's one among other values using by 'interest rate amount calculation' method
                                Console.Write("\nSpecify a depositing term (in months): ");
                                while (!Int32.TryParse(Console.ReadLine(), out userChoice) || userChoice < 1)
                                {
                                    Console.Write("\nDepositing term must contain only digits above zero !\nPlease specify a valid term: ");
                                }
                                Console.Write("Account current balance including interest rate amount: {0}", I1Acc.accruedAmount(userChoice));
                                break;

                            case 5: // 'add a preferrable amount to an acc's available balance' operation
                                I2Acc = (I2)accList[accId];
                                I2Acc.currBalAddition(accAmount);
                                break;

                            case 6: // 'withdraw preferrable amount from an acc's available balance' operation
                                I2Acc = (I2)accList[accId];
                                I2Acc.currBalSubstract(accAmount);
                                break;

                            case 7: // the total acc's amount withdrawal operation
                                accList[accId].accClose();
                                break;
                        }
                        break;

                    case 3: // case to show a status of the BankAcc
                        Console.Write("\nID\tTYPE\t\t\tNAME\t\t\tCURRENT BALANCE");
                        foreach (BankAccount anAcc in accList)
                        {
                            Console.Write("\n{0}\t{1}\t\t{2}\t\t\t{3}", anAcc.GetId, anAcc.GetType().Name, anAcc.Owner, anAcc.CurrBalance);
                        }
                        break;
                }
            } while (true);
        }
    }
}
