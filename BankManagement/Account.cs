using System;
using BankManagement;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace BankManagement
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string IdOfBank { get; set; }
        public string AccountHolderName { get; set; }
        public double AccountAmount = 0;
        public List<TransactionHistory> TransactionHistoryData = new List<TransactionHistory>();
        public static void AddAccount()
        {

            List<Bank> banks = BankManagement.GetAllBanks();
            foreach (Bank bank in banks)
            {
                Console.WriteLine("Bank id is: " + bank.BankId + "Bank name is: " + bank.BankName);
            }

            Account ac = new Account();
            if (BankManagement.banks.Count > 0)
            {
            enterBankIdNumber:


                Console.WriteLine("Enter Bank id which you want to create:");
                string bankIdNumber;

                try
                {
                    bankIdNumber = Console.ReadLine();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter valid Bank id number");
                    goto enterBankIdNumber;
                }
                if(bankIdNumber.Length <3) 
                {
                    Console.WriteLine("Enter valid bank id");
                    goto enterBankIdNumber;
                }

                bool isBankExist = false;
                
                for (int i = 0; i < BankManagement.banks.Count; i++)
                {

                    if (BankManagement.banks[i].BankId == bankIdNumber)
                    {
                        isBankExist = true;
                        break;
                    }

                }
                if (isBankExist == true)
                {
                    Bank bankObject = BankManagement.GetBankById(bankIdNumber);


                    string accountName;
                enterAccountName: Console.WriteLine("Enter Account Name: ");
                    accountName = Console.ReadLine();
                    string nameRegex = @"^[a-zA-Z ]+$";
                    Regex r = new Regex(nameRegex);

                    if (!r.IsMatch(accountName) || accountName == "")
                    {
                        Console.WriteLine("Enter string as name");
                        goto enterAccountName;

                    }
                    else if (accountName.Length < 3)
                    {
                        Console.WriteLine("Account number should be more than 3 letters");
                        goto enterAccountName;
                    }

                    ac.AccountNumber = accountName.Substring(0, 3) + DateTime.Now.ToString("ddMMyyyy");
                    ac.AccountHolderName = accountName;
                    ac.IdOfBank = bankIdNumber;
                    foreach (var userAccount in bankObject.accounts)
                    {
                        if (userAccount.AccountNumber == ac.AccountNumber)
                        {
                            Console.WriteLine("Account Already exist");
                            goto enterAccountName;
                        }
                    }
                    bankObject.accounts.Add(ac);

                }

            }
            else
            {
                Console.WriteLine("No banks are there to create account");
            }
        }
        public static void DeleteAccount()
        {
            if (BankManagement.banks.Count > 0)
            {
            enterBankIdNumber:


                Console.WriteLine("Enter Bank id of the account :");
                string bankIdnumber;

                try
                {
                    bankIdnumber = Console.ReadLine();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter valid Bank id number");
                    goto enterBankIdNumber;
                }
                if (bankIdnumber.Length < 3)
                {
                    Console.WriteLine("Enter valid bank id");
                    goto enterBankIdNumber;
                }
                bool isBankExist = false;
                for (int i = 0; i < BankManagement.banks.Count; i++)
                {

                    if (BankManagement.banks[i].BankId == bankIdnumber)
                    {
                        isBankExist = true;
                        break;
                    }

                }
                if (isBankExist == true)
                {
                    Bank bankObject = BankManagement.GetBankById(bankIdnumber);
                    string accountId;
                enterAccountId: Console.WriteLine("Enter Account Number");

                    try
                    {
                        accountId = Console.ReadLine();

                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Enter valid Account number");
                        goto enterAccountId;
                    }
                    if(accountId.Length< 3)
                    {
                        Console.WriteLine("Enter valid account number");
                        goto enterAccountId;
                    }
                    Account ac = new Account();
                    bool isAccountExist = false;

                    foreach (Account st in bankObject.accounts)
                    {
                        if (st.AccountNumber == accountId)
                        {
                            isAccountExist = true;
                            break;
                        }

                    }
                    if (isAccountExist == true)
                    {
                        ac = bankObject.accounts.Find(x => x.AccountNumber == accountId);
                        bankObject.accounts.Remove(ac);
                    }
                    else
                    {
                        Console.WriteLine("Account not available");
                    }


                }
                else
                {
                    Console.WriteLine("Bank not available");
                }
            }
        }

        public static void DepositAmount()
        {
            if (BankManagement.banks.Count > 0)
            {
            enterBankIdNumber:


                Console.WriteLine("Enter Bank id of the account :");
                string bankIdnumber;

                try
                {
                    bankIdnumber = Console.ReadLine();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter valid Bank id number");
                    goto enterBankIdNumber;
                }
                if (bankIdnumber.Length < 3)
                {
                    Console.WriteLine("Enter valid bank id");
                    goto enterBankIdNumber;
                }
                bool isBankExist = false;
                for (int i = 0; i < BankManagement.banks.Count; i++)
                {

                    if (BankManagement.banks[i].BankId == bankIdnumber)
                    {
                        isBankExist = true;
                        break;
                    }

                }
                if (isBankExist == true)
                {
                    Bank bankObject = BankManagement.GetBankById(bankIdnumber);
                    string accountId;
                enterAccountId: Console.WriteLine("Enter Account Number");

                    try
                    {
                        accountId = Console.ReadLine();

                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Enter valid Account number");
                        goto enterAccountId;
                    }
                    if (accountId.Length < 3)
                    {
                        Console.WriteLine("Enter valid account number");
                        goto enterAccountId;
                    }
                    Account ac = new Account();
                    bool isAccountExist = false;

                    foreach (Account st in bankObject.accounts)
                    {
                        if (st.AccountNumber == accountId)
                        {
                            isAccountExist = true;
                            break;
                        }

                    }
                    if (isAccountExist == true)
                    {

                        foreach (var currency in bankObject.AcceptableCurrency)
                        {
                            Console.WriteLine("Currency name: " + currency.Key);
                        }
                        string currencyName;
                    enterCurrencyName: Console.WriteLine("Enter Currency Name: ");
                        currencyName = Console.ReadLine().ToUpper();
                        string nameRegex = @"^[a-zA-Z ]+$";
                        Regex r = new Regex(nameRegex);

                        if (!r.IsMatch(currencyName) || currencyName == "")
                        {
                            Console.WriteLine("Enter string as name");
                            goto enterCurrencyName;

                        }
                        double ratioOfCurrency;
                        if (bankObject.AcceptableCurrency.Keys.Contains(currencyName))
                        {
                            ratioOfCurrency = bankObject.AcceptableCurrency[currencyName];
                        }
                        else
                        {
                            Console.WriteLine("Currency not available");
                            goto enterCurrencyName;
                        }
                    enterDepositAmount:


                        Console.WriteLine("Enter The Amount to deposit: ");
                        int depositAmount;

                        try
                        {
                            depositAmount = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Enter valid Amount");
                            goto enterDepositAmount;
                        }
                        ac = bankObject.accounts.Find(x => x.AccountNumber == accountId);
                        ac.AccountAmount += depositAmount * ratioOfCurrency;

                        Console.WriteLine(ac.AccountAmount);

                    }
                    else
                    {
                        Console.WriteLine("Account not available");
                    }


                }
                else
                {
                    Console.WriteLine("Bank not available");
                }
            }
        }
        public static void WithdrawAmount()
        {
            if (BankManagement.banks.Count > 0)
            {
            enterBankIdNumber:


                Console.WriteLine("Enter Bank id of the account :");
                string bankIdnumber;

                try
                {
                    bankIdnumber = Console.ReadLine();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter valid Bank id number");
                    goto enterBankIdNumber;
                }
                if (bankIdnumber.Length < 3)
                {
                    Console.WriteLine("Enter valid bank id");
                    goto enterBankIdNumber;
                }
                bool isBankExist = false;
                for (int i = 0; i < BankManagement.banks.Count; i++)
                {

                    if (BankManagement.banks[i].BankId == bankIdnumber)
                    {
                        isBankExist = true;
                        break;
                    }

                }
                if (isBankExist == true)
                {
                    Bank bankObject = BankManagement.GetBankById(bankIdnumber);
                    string accountId;
                enterAccountId: Console.WriteLine("Enter Account Number");

                    try
                    {
                        accountId = Console.ReadLine();

                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Enter valid Account number");
                        goto enterAccountId;
                    }
                    if (accountId.Length < 3)
                    {
                        Console.WriteLine("Enter valid account number");
                        goto enterAccountId;
                    }
                    Account ac = new Account();
                    bool isAccountExist = false;

                    foreach (Account st in bankObject.accounts)
                    {
                        if (st.AccountNumber == accountId)
                        {
                            isAccountExist = true;
                            break;
                        }

                    }
                    if (isAccountExist == true)
                    {
                    enterWithdrawAmount:


                        Console.WriteLine("Enter The Amount to WithDraw: ");
                        int withdrawAmount;

                        try
                        {
                            withdrawAmount = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Enter valid Amount");
                            goto enterBankIdNumber;
                        }
                        ac = bankObject.accounts.Find(x => x.AccountNumber == accountId);
                        ac.AccountAmount -= withdrawAmount;

                        Console.WriteLine(ac.AccountAmount);

                    }
                    else
                    {
                        Console.WriteLine("Account not available");
                    }


                }
                else
                {
                    Console.WriteLine("Bank not available");
                }
            }
        }
        public static void AcceptedCurency()
        {
            if (BankManagement.banks.Count > 0)
            {
            enterBankIdNumber:


                Console.WriteLine("Enter Bank id of the account :");
                string bankIdnumber;

                try
                {
                    bankIdnumber = Console.ReadLine();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter valid Bank id number");
                    goto enterBankIdNumber;
                }
                if (bankIdnumber.Length < 3)
                {
                    Console.WriteLine("Enter valid bank id");
                    goto enterBankIdNumber;
                }
                bool isBankExist = false;
                for (int i = 0; i < BankManagement.banks.Count; i++)
                {

                    if (BankManagement.banks[i].BankId == bankIdnumber)
                    {
                        isBankExist = true;
                        break;
                    }
                   

                }
                if (isBankExist == true)
                {
                    Bank bankObject = BankManagement.GetBankById(bankIdnumber);
                    string currencyName;

                enterCurrencyName: Console.WriteLine("Enter Currency Name: ");
                    currencyName = Console.ReadLine();
                    string nameRegex = @"^[a-zA-Z ]+$";
                    Regex r = new Regex(nameRegex);

                    if (!r.IsMatch(currencyName) || currencyName == "")
                    {
                        Console.WriteLine("Enter string as name");
                        goto enterCurrencyName;

                    }
                enterCurrencyRatio:
                    Console.WriteLine("Enter Currency Ratio of the bank :");
                    double currencyRatio;

                    try
                    {
                        currencyRatio = Convert.ToDouble(Console.ReadLine());

                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Enter valid ratio");
                        goto enterBankIdNumber;
                    }
                    if (currencyRatio == 0)
                    {
                        Console.WriteLine("Zero is not acceptable");
                        goto enterCurrencyRatio;
                    }
                   foreach(var currency in bankObject.AcceptableCurrency.Keys)
                    {
                        if (currency==currencyName.ToUpper())
                        {
                            Console.WriteLine("Currency type already exists");
                            goto enterCurrencyName;
                        }
                    }
                    
                    bankObject.AcceptableCurrency.Add(currencyName.ToUpper(), currencyRatio);
                }
                else
                {
                    Console.WriteLine("Bank not available");
                }
            }
        }
        public static void TransferFunds()
        {
            Bank senderBank = new Bank();
            if (BankManagement.banks.Count > 0)
            {
            enterSenderBankIdNumber:
                Console.WriteLine("Enter Bank id of the sender account :");
                string senderBankIdnumber;
                try
                {
                    senderBankIdnumber = Console.ReadLine();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter valid Bank id number");
                    goto enterSenderBankIdNumber;
                }
                if (senderBankIdnumber.Length < 3)
                {
                    Console.WriteLine("Enter valid bank id");
                    goto enterSenderBankIdNumber;
                }
                bool isSenderBankExist = false;
                for (int i = 0; i < BankManagement.banks.Count; i++)
                {

                    if (BankManagement.banks[i].BankId == senderBankIdnumber)
                    {
                        isSenderBankExist = true;
                        break;
                    }

                }
                if (isSenderBankExist == true)
                {
                    Bank senderBankObject = BankManagement.GetBankById(senderBankIdnumber);
                    Account senderAccount = new Account();
                    string senderAccountId;
                enterSenderAccountId: Console.WriteLine("Enter sender Account Number");

                    try
                    {
                        senderAccountId = Console.ReadLine();

                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Enter valid Account number");
                        goto enterSenderAccountId;
                    }
                    if (senderAccountId.Length < 3)
                    {
                        Console.WriteLine("Enter valid account number");
                        goto enterSenderAccountId;
                    }
                    Account ac = new Account();
                    bool isSenderAccountExist = false;
                    foreach (Account st in senderBankObject.accounts)
                    {
                        if (st.AccountNumber == senderAccountId)
                        {
                            isSenderAccountExist = true;
                            break;
                        }

                    }
                    if (isSenderAccountExist == true)
                    {
                        ac = senderBankObject.accounts.Find(x => x.AccountNumber == senderAccountId);

                        Bank recieverBank = new Bank();
                        if (BankManagement.banks.Count > 0)
                        {
                        enterRecieverBankIdNumber:


                            Console.WriteLine("Enter Bank id of the reciever account :");
                            string recieverBankIdnumber;

                            try
                            {
                                recieverBankIdnumber = Console.ReadLine();
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine("Enter valid Bank id number");
                                goto enterRecieverBankIdNumber;
                            }
                            if (recieverBankIdnumber.Length < 3)
                            {
                                Console.WriteLine("Enter valid bank id");
                                goto enterRecieverBankIdNumber;
                            }
                            bool isRecieverBankExist = false;
                            for (int j = 0; j < BankManagement.banks.Count; j++)
                            {

                                if (BankManagement.banks[j].BankId == recieverBankIdnumber)
                                {
                                    isRecieverBankExist = true;
                                    break;
                                }

                            }
                            if (isRecieverBankExist == true)
                            {
                                Bank recieverBankObject = BankManagement.GetBankById(recieverBankIdnumber);
                                Account recieverAccount = new Account();
                                string recieverAccountId;
                            enterRecieverAccountId: Console.WriteLine("Enter reciever Account Number");

                                try
                                {
                                    recieverAccountId = Console.ReadLine();

                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine("Enter valid Account number");
                                    goto enterRecieverAccountId;
                                }
                                if (recieverAccountId.Length < 3)
                                {
                                    Console.WriteLine("Enter valid account number");
                                    goto enterRecieverAccountId;
                                }
                                Account rac = new Account();
                                bool isRecieverAccountExist = false;
                                foreach (Account st in recieverBankObject.accounts)
                                {
                                    if (st.AccountNumber == recieverAccountId)
                                    {
                                        isRecieverAccountExist = true;
                                        break;
                                    }

                                }
                                if (isRecieverAccountExist == true)
                                {
                                    if (senderAccountId == recieverAccountId && senderBankIdnumber == recieverBankIdnumber)
                                    {
                                        Console.WriteLine("It's not a legal transaction");

                                    }
                                    else
                                    {


                                        rac = recieverBankObject.accounts.Find(x => x.AccountNumber == recieverAccountId);
                                    enterAmountToTransfer:


                                        Console.WriteLine("Enter The Amount to Transfer: ");
                                        double transferAmount;
                                        double totalAmount;

                                        try
                                        {
                                            transferAmount = Convert.ToInt32(Console.ReadLine());

                                        }
                                        catch (FormatException ex)
                                        {
                                            Console.WriteLine("Enter valid Amount");
                                            goto enterAmountToTransfer;
                                        }
                                        if (transferAmount < 0)
                                        {
                                            goto enterAmountToTransfer;
                                        }
                                        if (ac.IdOfBank == rac.IdOfBank)
                                        {
                                            if (transferAmount < 200000)
                                            {
                                                totalAmount = transferAmount + (transferAmount * senderBank.SameBankRtgs);
                                            }
                                            else
                                            {
                                                totalAmount = transferAmount + (transferAmount * senderBank.SameBankImps);
                                            }
                                        }
                                        else
                                        {
                                            if (transferAmount < 200000)
                                            {
                                                totalAmount = transferAmount + (transferAmount * senderBank.DifferentBankRtgs);
                                            }
                                            else
                                            {
                                                totalAmount = transferAmount + (transferAmount * senderBank.DifferentBankImps);
                                            }
                                        }
                                        if (ac.AccountAmount >= totalAmount)
                                        {
                                            ac.AccountAmount -= totalAmount;
                                            rac.AccountAmount += transferAmount;
                                            string transactionId = "TXN" + ac.IdOfBank + ac.AccountNumber + DateTime.Now.ToString("ddMMyyyy");
                                            TransactionHistory senderTransactionHistories = new TransactionHistory();
                                            senderTransactionHistories.TransactionId = transactionId;
                                            senderTransactionHistories.SenderBankId = ac.IdOfBank;
                                            senderTransactionHistories.SenderAccountId = ac.AccountNumber;
                                            senderTransactionHistories.RecieverBankId = rac.IdOfBank;
                                            senderTransactionHistories.RecieverAccountId += rac.AccountNumber;
                                            senderTransactionHistories.TransactionAmount = transferAmount;
                                            senderTransactionHistories.TransactionType = "sent";
                                            ac.TransactionHistoryData.Add(senderTransactionHistories);
                                            TransactionHistory recieverTransactionHistories = new TransactionHistory();
                                            recieverTransactionHistories.TransactionId = transactionId;
                                            recieverTransactionHistories.SenderBankId = ac.IdOfBank;
                                            recieverTransactionHistories.SenderAccountId = ac.AccountNumber;
                                            recieverTransactionHistories.RecieverBankId = rac.IdOfBank;
                                            recieverTransactionHistories.RecieverAccountId += rac.AccountNumber;
                                            recieverTransactionHistories.TransactionAmount = transferAmount;
                                            recieverTransactionHistories.TransactionType = "received";
                                            rac.TransactionHistoryData.Add(recieverTransactionHistories);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Insufficient Balance");
                                        }
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Account not available");
                                }

                            }
                            else
                            {
                                Console.WriteLine("Bank not available");
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Account not available");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Bank not available");
                }

            }
        }
        public static void TransactionHistory()
        {
            if (BankManagement.banks.Count > 0)
            {
            enterBankIdNumber:


                Console.WriteLine("Enter Bank id of the account :");
                string bankIdnumber;

                try
                {
                    bankIdnumber = Console.ReadLine();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter valid Bank id number");
                    goto enterBankIdNumber;
                }
                if (bankIdnumber.Length < 3)
                {
                    Console.WriteLine("Enter valid bank id");
                    goto enterBankIdNumber;
                }

                bool isBankExist = false;
                for (int i = 0; i < BankManagement.banks.Count; i++)
                {
                    if (BankManagement.banks[i].BankId == bankIdnumber)
                    {
                        isBankExist = true;
                        break;
                    }

                }
                if (isBankExist == true)
                {
                    Bank bankObject = BankManagement.GetBankById(bankIdnumber);
                    Account account = new Account();
                    string accountId;
                enterAccountId: Console.WriteLine("Enter Account Number");

                    try
                    {
                        accountId = Console.ReadLine();

                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Enter valid Account number");
                        goto enterAccountId;
                    }
                    if (accountId.Length < 3)
                    {
                        Console.WriteLine("Enter valid account number");
                        goto enterAccountId;
                    }
                    Account ac = new Account();
                    bool isAccountExist = false;

                    foreach (Account st in bankObject.accounts)
                    {
                        if (st.AccountNumber == accountId)
                        {
                            isAccountExist = true;
                            break;
                        }

                    }
                    if (isAccountExist == true)
                    {
                        ac = bankObject.accounts.Find(x => x.AccountNumber == accountId);
                        foreach (var transaction in ac.TransactionHistoryData)
                        {
                            Console.WriteLine("Transaction id: " + transaction.TransactionId + " Transaction type: " + transaction.TransactionType + " Sender Account id: " + transaction.SenderAccountId + " Sender bank id: " + transaction.SenderBankId + " Reciever account id: " + transaction.RecieverAccountId + " Reciever bank id: " + transaction.RecieverBankId + " Transaction amount: " + transaction.TransactionAmount + " ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Account not available");
                    }
                }
                else
                {
                    Console.WriteLine("Bank not available");
                }
            }
        }
        public static void TransactionRevert()
        {
            if (BankManagement.banks.Count > 0)
            {
            enterBankIdNumber:


                Console.WriteLine("Enter Bank id of the account :");
                string bankIdnumber;

                try
                {
                    bankIdnumber = Console.ReadLine();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter valid Bank id number");
                    goto enterBankIdNumber;
                }
                if (bankIdnumber.Length < 3)
                {
                    Console.WriteLine("Enter valid bank id");
                    goto enterBankIdNumber;
                }
                bool isBankExist = false;
                for (int i = 0; i < BankManagement.banks.Count; i++)
                {

                    if (BankManagement.banks[i].BankId == bankIdnumber)
                    {
                        isBankExist = true;
                        break;
                    }

                }
                if (isBankExist == true)
                {
                    Bank bankObject = BankManagement.GetBankById(bankIdnumber);
                    Account account = new Account();
                    string accountId;
                enterAccountId: Console.WriteLine("Enter Account Number");

                    try
                    {
                        accountId = Console.ReadLine();

                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Enter valid Account number");
                        goto enterAccountId;
                    }
                    if (accountId.Length < 3)
                    {
                        Console.WriteLine("Enter valid account number");
                        goto enterAccountId;
                    }
                    Account ac = new Account();
                    bool isAccountExist = false;

                    foreach (Account st in bankObject.accounts)
                    {
                        if (st.AccountNumber == accountId)
                        {
                            isAccountExist = true;
                            break;
                        }

                    }
                    if (isAccountExist == true)
                    {
                        ac = bankObject.accounts.Find(x => x.AccountNumber == accountId);

                        string transactionId;
                        string receiverBankId = "";
                        string receieverAccountId = "";
                        double receieverAmount = 0;
                        Console.WriteLine("Enter transation id to revert:");
                        transactionId = Console.ReadLine();
                        foreach (var transation in ac.TransactionHistoryData)
                        {
                            if (transactionId == transation.TransactionId)
                            {
                                receiverBankId = transation.RecieverBankId;
                                receieverAccountId = transation.RecieverAccountId;
                                receieverAmount = transation.TransactionAmount;
                                ac.TransactionHistoryData.Remove(transation);
                                break;

                            }
                        }
                        Account rac = new Account();
                        Bank recieverBankObject = BankManagement.GetBankById(receiverBankId);
                        rac = recieverBankObject.accounts.Find(x => x.AccountNumber == receieverAccountId);
                        foreach (var recieverTransaction in rac.TransactionHistoryData)
                        {
                            if (transactionId == recieverTransaction.TransactionId)
                            {
                                rac.TransactionHistoryData.Remove(recieverTransaction);
                                break;
                            }
                        }
                        ac.AccountAmount += receieverAmount;
                        rac.AccountAmount -= receieverAmount;
                    }
                    else
                    {
                        Console.WriteLine("Account not available");
                    }
                }
                else
                {
                    Console.WriteLine("Bank not available");
                }
            }
        }
        public static void BalanceEnquiry()
        {
            if (BankManagement.banks.Count > 0)
            {
            enterBankIdNumber:


                Console.WriteLine("Enter Bank id of the account :");
                string bankIdnumber;

                try
                {
                    bankIdnumber = Console.ReadLine();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter valid Bank id number");
                    goto enterBankIdNumber;
                }
                if (bankIdnumber.Length < 3)
                {
                    Console.WriteLine("Enter valid bank id");
                    goto enterBankIdNumber;
                }
                bool isBankExist = false;
                for (int i = 0; i < BankManagement.banks.Count; i++)
                {

                    if (BankManagement.banks[i].BankId == bankIdnumber)
                    {
                        isBankExist = true;
                        break;
                    }

                }
                if (isBankExist == true)
                {
                    Bank bankObject = BankManagement.GetBankById(bankIdnumber);
                    Account account = new Account();
                    string accountId;
                enterAccountId: Console.WriteLine("Enter Account Number");

                    try
                    {
                        accountId = Console.ReadLine();

                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Enter valid Account number");
                        goto enterAccountId;
                    }
                    if (accountId.Length < 3)
                    {
                        Console.WriteLine("Enter valid account number");
                        goto enterAccountId;
                    }
                    Account ac = new Account();
                    bool isAccountExist = false;
                    foreach (Account st in bankObject.accounts)
                    {
                        if (st.AccountNumber == accountId)
                        {
                            isAccountExist = true;
                            break;
                        }

                    }
                    if (isAccountExist == true)
                    {
                        ac = bankObject.accounts.Find(x => x.AccountNumber == accountId);
                        Console.WriteLine("Your account balance is: " + ac.AccountAmount);
                    }
                    else
                    {
                        Console.WriteLine("Account not available");
                    }
                }
                 else
                {
                    Console.WriteLine("Bank not available");
                }
            }
        }
    }
}




