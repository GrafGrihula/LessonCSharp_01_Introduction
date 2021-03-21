using System;
using System.Collections.Generic;
using System.Text;

namespace Staffer
{
    class Employee
    {
        public static int CURRENT_YEAR = 2021;

        public string surname { get; set; }
        public string secondName { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public float salary { get; set; }
        public int birthYear { get; set; }

        // 2.	Конструктор класса должен заполнять эти поля при создании объекта;
        public Employee(string name,
                  string secondName,
                  string surname,
                  string phone,
                  string email,
                  string position,
                  float salary,
                  int birthYear)
        {
            this.birthYear = birthYear;
            this.name = name;
            this.surname = surname;
            this.secondName = secondName;
            this.position = position;
            this.phone = phone;
            this.salary = salary;
            this.email = email;
        }

        // 3.	Внутри класса «Сотрудник» написать методы, которые возвращают
        // значение каждого поля;
        public int getAge()
        {
            return CURRENT_YEAR - birthYear;
        }

        public string GetFullInfo()
        {
            return
                    this.name + " " +
                    this.secondName + " " +
                    this.surname + ",\n" +
                    this.getAge() + " лет, " +
                    this.position + ". \nТелефон: " +
                    this.phone + ". \nЗарплата " +
                    this.salary + " RUR.\n" +
                    this.email + "\n\n";
                    
        }
    }
}
