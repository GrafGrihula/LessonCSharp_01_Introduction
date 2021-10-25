using System;
using System.Collections.Generic;
using System.Text;

namespace Finances03
{
    class CreateBankAccount : Program
    {
        public void StartMenu()
        {
            Console.WriteLine("Навигация по менеджеру счетов:\r\n" +
                "'N' - создать счёт\t'X' - удалить счёт\r\n" +
                "'+' - пополнить счёт\t'-' - снять со счёта\r\n" +
                "'T' - перевод средств");

            string key = Console.ReadLine();

            switch (key)
            {
                case "N":
                    Console.WriteLine();
                    CreateNewBankAccount();
                    break;

                case "X":
                    Console.WriteLine();
                    DeleteBankAccount();
                    break;

                case "+":
                    Console.WriteLine();

                    Console.Write("Укажите счёт для пополнения: ");
                    int accountUp = int.Parse(Console.ReadLine().Trim());

                    Console.Write("Введите сумму для пополнения: ");
                    double sumUp = double.Parse(Console.ReadLine().Trim());

                    UpLoadSum(accountUp, sumUp);
                    break;

                case "-":
                    Console.WriteLine();

                    Console.Write("Укажите счёт для списания: ");
                    int accountDown = int.Parse(Console.ReadLine().Trim());

                    Console.Write("Введите сумму для снятия со счёта: ");
                    double sumDown = double.Parse(Console.ReadLine().Trim());

                    DownLoadSum(accountDown, sumDown);
                    break;

                case "T":
                    Console.WriteLine();

                    Console.Write("Укажите счёт для списания: ");
                    int accountFrom = int.Parse(Console.ReadLine().Trim());

                    Console.Write("Укажите счёт для пополнения: ");
                    int accountTo = int.Parse(Console.ReadLine().Trim());

                    Console.Write("Введите сумму перевода: ");
                    double sum = double.Parse(Console.ReadLine().Trim());

                    MoneyTransaction(accountFrom, accountTo, sum);
                    break;


                default:
                    Console.WriteLine("Неверно! Введите один из предложенных символов.");
                    break;
            }
        }

        public void View()
        {
            Console.WriteLine();
            Console.WriteLine(new string('*', 50));
            Console.WriteLine("СПИСОК СЧЕТОВ:");
            Console.WriteLine();

            foreach (KeyValuePair<int, BankAccount> bankAccount in bankAccounts)
            {
                Console.WriteLine();
                Console.WriteLine($"Номер счёта:\t\t{bankAccount.Key}");
                Console.WriteLine($"Тип счёта:\t\t{bankAccount.Value.TypeAccount}");
                Console.WriteLine($"Баланс:\t\t\t{bankAccount.Value.Balance}");
                //Console.WriteLine($"Номер транзакции:\t{bankAccount.Value.AccountNumber()}");
                Console.WriteLine();
            }

            Console.WriteLine(new string('*', 50));
            Console.WriteLine();

            StartMenu();
        }

        public void CreateNewBankAccount()
        {
            Console.Write($"Списки типов счетов:\r\n" +
                $"1 - {TypeAccount.JointAccount}\r\n" +
                $"2 - {TypeAccount.CheckingAccount}\r\n" +
                $"3 - {TypeAccount.SavingsAccount}\r\n" +
                $"Укажите порядковый номер счёта для открытия: ");

            TypeAccount typeAccount = (TypeAccount)int.Parse(Console.ReadLine());

            bankAccounts.Add(
                ++accountID,
                new BankAccount()
                {
                    TypeAccount = typeAccount,
                    Balance = 0
                });

            View();
        }

        public void DeleteBankAccount()
        {
            Console.Write($"Укажите номер счёта для удаления: ");

            int id = int.Parse(Console.ReadLine());

            bankAccounts.Remove(id);

            View();
        }

        public void UpLoadSum(int account, double sum)
        {
            bankAccounts[account].Balance += sum;

            Console.WriteLine("Успешно!");

            View();
        }

        public void DownLoadSum(int account, double sum)
        {
            double balance = bankAccounts[account].Balance;
            if (balance < sum)
            {
                Console.WriteLine("Недостаточно средств!");
            }
            else
            {
                Console.WriteLine("Успешно!");
                balance -= sum;
            }
            bankAccounts[account].Balance = balance;

            View();
        }

        public void MoneyTransaction(int accountFrom, int accountTo, double sum)
        {
            double balanceFrom = bankAccounts[accountFrom].Balance;
            double balanceTo = bankAccounts[accountTo].Balance;
            if (balanceFrom < sum)
            {
                Console.WriteLine("Недостаточно средств!");
            }
            else
            {
                Console.WriteLine("Успешно!");
                balanceFrom -= sum;
                balanceTo += sum;
            }
            bankAccounts[accountFrom].Balance = balanceFrom;
            bankAccounts[accountTo].Balance = balanceTo;

            View();
        }

    }
}
