using System;

namespace PhoneDirectory
{
    class ProgramPhoneDirectory
    {
        static void Main(string[] args)
        {
            string[,] arrayPhone = {
            { "Иванов", "+79998887777" },
            { "Петров", "+78887776655" },
            { "Сидоров", "sidorofff@smail.si" },
            { "Васичкин", "vasichkin@vmail.va" },
            { "Череззаборногузадирищенко", "footup@fmail.fu" }
            };
            for (int i = 0; i < arrayPhone.GetLength(0); i++)
            {
                for (int j = 0; j < arrayPhone.GetLength(1); j++)
                {
                    Console.Write(arrayPhone[i, j] + " ");
                }
                Console.WriteLine();
            }            
        }
    }
}
