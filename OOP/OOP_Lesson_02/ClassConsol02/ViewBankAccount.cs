using System;

namespace Finances
{
    class ViewBankAccount
    {
        BankAccount bankAccount = new BankAccount();
        ConsoleLine consoleLine = new ConsoleLine();

        string _typeOfBankAccount;
        Guid _accountNumber;
        float _balance;


        public void ViewAccountSet()
        {
            _typeOfBankAccount = bankAccount.TypeOfBankAccount;
            _accountNumber = bankAccount.AccountNumber;
            _balance = bankAccount.Balance;
        }


        public void ViewAccountGet()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(
                $" Тип счёта: {_typeOfBankAccount}\r\n" +
                $" Номер счёта: {_accountNumber}\r\n" +
                $" Баланс: {_balance} руб.");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Нажмите:\r\n" +
                " '+' - для пополнения счёта\r\n" +
                " '-' - для снятия со счёта");

            string action = Console.ReadLine().Trim();

            if (action == "+")
            {
                _balance = bankAccount.UpLoad(_balance);
            }
            else if (action == "-")
            {
                _balance = bankAccount.DownLoad(_balance);
            }
            else
            {
                consoleLine.ConsoleWrite(ConsoleColor.Red, "Неверный ввод!");
            }

            ViewAccount();
        }

        public void ViewAccount()
        {
            ViewAccountGet();
        }
    }
}
