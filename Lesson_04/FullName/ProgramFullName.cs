using System;

namespace FullName
{
    /// <summary>
    /// 1. Написать метод GetFullName(string firstName, string lastName, string patronymic),
    /// принимающий на вход ФИО в разных аргументах и возвращающий объединённую 
    /// строку с ФИО. Используя метод, написать программу, выводящую в консоль 
    /// 3–4 разных ФИО.
    /// </summary>
    class ProgramFullName
    {
        static void Main(string[] args)
        {
            string answer = null;
            do
            {
                Console.Write("Введите Фамилию: ");
                string firstName = Console.ReadLine();

                Console.Write("Введите Имя: ");
                string lastName = Console.ReadLine();

                Console.Write("Введите Отчество: ");
                string patronymic = Console.ReadLine();

                Console.WriteLine($"ФИО: {GetFullName(firstName, lastName, patronymic)}");
                Console.WriteLine();

                Console.Write("Ещё? (нет - 'любая кнопка', да - '+'):");
                answer = Console.ReadLine();

                Console.WriteLine();
            } 
            while (answer == "+");
            
            Console.ReadLine();
        }

        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            string fullName = $"{firstName} {lastName} {patronymic}";
            return fullName;
        }
    }
}
