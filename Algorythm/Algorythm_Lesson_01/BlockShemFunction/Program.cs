using System;

namespace BlockShemFunction
{
    class Program
    {
        /// <summary>
        /// Класс тестовых случаев
        /// </summary>
        public class TestCase
        {
            public int number { get; set; } // Значение переменной
            public string Expected { get; set; } // Ожидаемый результат
            public Exception ExpectedException { get; set; } // Ошибка
        }

        /// <summary>
        /// Метод тестирования
        /// </summary>
        /// <param name="testCase">Экземпляр класса "тестового случая"</param>
        static void TestNumber(TestCase testCase)
        {
            try
            {
                var actual = PrimeNumber( testCase.number );

                if( actual == testCase.Expected )
                {
                    Console.WriteLine( "VALID TEST" );
                }
                else
                {
                    Console.WriteLine( "I N V A L I D   T E S T" );
                }
            }
            catch/*(Exception ex)*/
            {
                if( testCase.ExpectedException != null )
                {
                    // TODO add type exception tests;
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine( "I N V A L I D   T E S T" );
                }
            }
        }


        static void Main(string[] args)
        {
            //Console.WriteLine( "Введите число: " );
            //PrimeNumber( int.Parse( Console.ReadLine() ) );

            // Тест № 1
            var testCase1 = new TestCase()
            {
                number = 1,
                Expected = "Nonprime",
                ExpectedException = null
            };
            TestNumber( testCase1 );

            // Тест № 2
            var testCase2 = new TestCase()
            {
                number = 2,
                Expected = "Prime",
                ExpectedException = null
            };
            TestNumber( testCase2 );

            // Тест № 3
            var testCase3 = new TestCase()
            {
                number = 3,
                Expected = "Prime",
                ExpectedException = null
            };
            TestNumber( testCase3 );

            // Тест № 4
            var testCase4 = new TestCase()
            {
                number = 4,
                Expected = "Nonprime",
                ExpectedException = null
            };
            TestNumber( testCase4 );

            // Тест № 5
            var testCase5 = new TestCase()
            {
                number = 5,
                Expected = "Prime",
                ExpectedException = null
            };
            TestNumber( testCase5 );

            // Тест № 6
            var testCase6 = new TestCase()
            {
                number = 6,
                Expected = "Nonprime",
                ExpectedException = null
            };
            TestNumber( testCase6 );
        }

        // Метод проверки числа на ПРОСТОТУ ДУШЕВНУЮ )))
        static string PrimeNumber(int number)
        {
            int d = 0;
            int i = 2;
            string result = null;

            while( i<number )
            {
                if( number%i == 0 )
                {
                    d++;
                }
                i++;
            }

            if( d == 0 && number != 1)
            {
                result = "Prime";
                Console.WriteLine($"Число {number} слишком ПРОСТОЕ.");
            }
            else
            {
                Console.WriteLine( $"Число {number} довольно-таки НЕ ПРОСТОЕ." );
                result = "Nonprime";
            }

            return result;
        }

    }
}
