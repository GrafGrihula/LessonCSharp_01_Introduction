using System;

namespace FibonacciNumber
{
    class ProgramFibonacciNumber
    {
        static void Main(string[] args)
        {
            Console.Write("Введите значение для вычисления числа Фибоначчи: ");
            int index = 0;
            index = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Число Фибоначчи для значения n={index} равно {FibonacciCalc(index)}");
            Console.Read();
        }

        static int FibonacciCalc(int index)
        {
            return FibonacciCalc(index, out _);
        }

        static int FibonacciCalc(int index, out int F1)
        {
            F1 = 0;
            if (index == 0)
            {
                return 0;
            }
            else if (index == 1)
            {
                return 1;
            }
            else 
            {
                int F2;
                F1 = FibonacciCalc(index - 1, out F2);
                return F1 + F2;
            }
        }
    }
}
