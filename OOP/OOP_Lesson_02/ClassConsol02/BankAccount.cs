using System;

namespace Finances
{
    class BankAccount
    {
        private static Guid _accountNumber;
        private float _balance;
        private string _typeOfBankAccount;
        private enum typeOfBankAccount
        {
            TotalScore = 0,                 // Общий счёт
            ForeignCurrencyAccount = 1,     // Валютный счёт
            CorrespondentAccount = 2,       // Корреспондентский счёт
            CheckingAccount = 3,            // Расчётный счёт
            SavingsAccount = 4              // Сберегательный счёт
        }

        ConsoleLine consoleLine = new ConsoleLine();

        public string TypeOfBankAccount
        {
            get
            {
                return _typeOfBankAccount;
            }

            set
            {
                _typeOfBankAccount = value;
            }
        }

        public Guid AccountNumber 
        {
            get
            {
                return _accountNumber = Guid.NewGuid();
            }
        }

        public float Balance 
        { 
            get
            {
                return _balance;
            }

            set
            {
                _balance = value;
            } 
        }


        public BankAccount() : this(0)
        {

        }

        public BankAccount(float balance) : this(0)
        {
            _balance = balance;
        }

        public BankAccount(int typeOfBankAccount) : this(typeOfBankAccount, 0)
        {
            _typeOfBankAccount =
                Enum.GetName(typeof(typeOfBankAccount), typeOfBankAccount);
        }

        public BankAccount(int typeOfBankAccount, float balance)
        {
            _typeOfBankAccount =
                Enum.GetName(typeof(typeOfBankAccount), typeOfBankAccount);
            _balance = balance;
        }

        public float UpLoad(float balance)
        {
            Console.ResetColor();
            Console.Write("Введите сумму для пополнения счёта: ");
            var sum = float.Parse(Console.ReadLine().Trim());
            _balance += sum;

            consoleLine.ConsoleWrite(ConsoleColor.Green, "Успешно!");

            return _balance; 
        }

        public float DownLoad(float balance)
        {
            Console.ResetColor();
            Console.Write("Введите сумму для снятия со счёта: ");
            var sum = float.Parse(Console.ReadLine().Trim());
            if (_balance < sum)
            {
                consoleLine.ConsoleWrite(ConsoleColor.Red, "Недостаточно средств!");
            }
            else
            {
                consoleLine.ConsoleWrite(ConsoleColor.Green, "Успешно!");
                _balance -= sum;
            }

            return _balance;
        }
    }
}
