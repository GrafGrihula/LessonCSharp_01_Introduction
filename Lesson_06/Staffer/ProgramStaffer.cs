using System;

namespace Staffer
{
    class ProgramStaffer
    {
        static void Main(string[] args)
        {
            //1.	Создать класс "Сотрудник" с полями: ФИО, должность, телефон,
            //зарплата, возраст;
            RandomText rt = new RandomText();

            Employee e = new Employee(rt.RandomFamiliya(), rt.RandomName(),
                    rt.RandomOtchestvo(), rt.RandomTelephone(), rt.RandomEmail(),
                    rt.RandomPost(), int.Parse( rt.RandomSalary()), int.Parse(rt.RandomAge()));

             //   5.Создать массив из 5 сотрудников.С помощью цикла вывести
             //информацию только о сотрудниках старше 40 лет;

            Employee[] employees = {
            e,
            new Employee(rt.RandomFamiliya(), rt.RandomName(),
                    rt.RandomOtchestvo(), rt.RandomTelephone(), rt.RandomEmail(),
                    rt.RandomPost(), int.Parse( rt.RandomSalary()), int.Parse(rt.RandomAge())),
            new Employee(rt.RandomFamiliya(), rt.RandomName(),
                    rt.RandomOtchestvo(), rt.RandomTelephone(), rt.RandomEmail(),
                    rt.RandomPost(), int.Parse( rt.RandomSalary()), int.Parse(rt.RandomAge())),
            new Employee(rt.RandomFamiliya(), rt.RandomName(),
                    rt.RandomOtchestvo(), rt.RandomTelephone(), rt.RandomEmail(),
                    rt.RandomPost(), int.Parse( rt.RandomSalary()), int.Parse(rt.RandomAge())),
            new Employee(rt.RandomFamiliya(), rt.RandomName(),
                    rt.RandomOtchestvo(), rt.RandomTelephone(), rt.RandomEmail(),
                    rt.RandomPost(), int.Parse( rt.RandomSalary()), int.Parse(rt.RandomAge()))
            };

            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i].getAge() > 40)
                    Console.WriteLine(employees[i].GetFullInfo());
            }

            Console.WriteLine("--------------------------------------------------------");

            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine(employees[i].GetFullInfo());
            }

            Console.WriteLine("--------------------------------------------------------");
        }
    

        
    }
}
