using System;

namespace Finances03
{
    class BankAccount
    {
        private double balance;
        private TypeAccount typeAccount;

        private static int accountNumber;

        public int AccountNumber()
        {
            return ++accountNumber;
        }

        public double Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public TypeAccount TypeAccount 
        {
            get { return this.typeAccount; }
            set { this.typeAccount = value; }
        }

        #region конструктор BankAccount

        public BankAccount() : this(TypeAccount.JointAccount)
        {
        }

        public BankAccount(double balance) : this(TypeAccount.JointAccount)
        {
            this.balance = balance;
        }

        public BankAccount(TypeAccount typeAccount) : this(typeAccount, 0)
        {
            this.typeAccount = typeAccount;
        }

        public BankAccount(TypeAccount typeAccount, double balance)
        {
            this.typeAccount = typeAccount;
            this.balance = balance;
        } 

        #endregion

    }
}
