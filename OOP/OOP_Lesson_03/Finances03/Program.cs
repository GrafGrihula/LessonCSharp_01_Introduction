using System;
using System.Collections.Generic;

namespace Finances03
{
    class Program
    {
        public int accountID;
        public Dictionary<int, BankAccount> bankAccounts = new Dictionary<int, BankAccount>();
        

        static void Main(string[] args)
        {
            CreateBankAccount createBankAccount = new CreateBankAccount();
            createBankAccount.StartMenu();
        }
    }
}
