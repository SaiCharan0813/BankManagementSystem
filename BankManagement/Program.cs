using BankManagement;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BankManagement
{
    class Program
    {
        public static void Main(string[] args)
        {
        
            int userChoice; bool flag = false;
            while (flag != true)
            {

            enterUserchoice: Console.WriteLine("1.Add Bank\n2.View All Banks\n3.Login To Bank\n4.Exit");

                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter valid choice");
                    goto enterUserchoice;
                }
                if (userChoice < 1 && userChoice > 4)
                {
                    Console.WriteLine("Enter valid choice");
                    goto enterUserchoice;
                }


                switch (userChoice)
                {
                    case 1:

                        Bank.AddBank();
                        break;
                    case 2:

                        BankManagement.DisplayAllBankss();
                        break;
                    case 3:
                        int loginChoice = 0;
                        if (BankManagement.banks.Count > 0)
                        {


                        enterLoginchoice: Console.WriteLine("1.Bank Staff\n2.User");

                            try
                            {
                                loginChoice = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine("Enter valid choice");
                                goto enterUserchoice;
                            }
                            if (loginChoice < 1 && loginChoice > 2)
                            {
                                Console.WriteLine("Enter valid choice");
                                goto enterUserchoice;
                            }
                            switch (loginChoice)
                            {
                                case 1:
                                    int staffChoice = 0;
                                enterStaffchoice: Console.WriteLine("1.Create Account\n2.Delete Account\n3.Add new currency\n4.Revert Transfer");

                                    try
                                    {
                                        staffChoice = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (FormatException ex)
                                    {
                                        Console.WriteLine("Enter valid choice");
                                        goto enterStaffchoice;
                                    }
                                    if (staffChoice < 1 && staffChoice > 5)
                                    {
                                        Console.WriteLine("Enter valid choice");
                                        goto enterStaffchoice;
                                    }
                                    switch (staffChoice)
                                    {
                                        case 1:
                                            Account.AddAccount();
                                            break;
                                        case 2:
                                            Account.DeleteAccount();
                                            break;
                                        case 3:
                                            Account.AcceptedCurency();
                                            break;
                                        case 4:
                                            Account.TransactionRevert();
                                            break;
                                    }
                                    break;

                                case 2:
                                    int accountUserChoice = 0;
                                enterAccountUserchoice: Console.WriteLine("1.Deposit Amount\n2.Withdraw Amount\n3.Transfer Funds\n4.Transaction History\n5.Balance Enquiry");

                                    try
                                    {
                                        accountUserChoice = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (FormatException ex)
                                    {
                                        Console.WriteLine("Enter valid choice");
                                        goto enterAccountUserchoice;
                                    }
                                    if (accountUserChoice < 1 && accountUserChoice > 4)
                                    {
                                        Console.WriteLine("Enter valid choice");
                                        goto enterAccountUserchoice;
                                    }
                                    switch (accountUserChoice)
                                    {
                                        case 1:
                                            Account.DepositAmount();
                                            break;
                                        case 2:
                                            Account.WithdrawAmount();
                                            break;
                                        case 3:
                                            Account.TransferFunds();
                                            break;
                                        case 4:
                                            Account.TransactionHistory();
                                            break;
                                        case 5:
                                            Account.BalanceEnquiry();
                                            break;
                                    }
                                    break;

                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no banks");
                        }
                            break;
                        
                    case 4:
                        Environment.Exit(0);
                        break;

                }
            }


        }
    }
}


