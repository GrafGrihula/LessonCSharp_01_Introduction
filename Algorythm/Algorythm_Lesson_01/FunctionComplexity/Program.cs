using System;

namespace FunctionComplexity
{
    class Program
    {
        /// <summary>
        /// Класс тестовых случаев
        /// </summary>
        public class TestCase
        {
            public int[] arrayNumber { get; set; } // Значение переменной
            public int Expected { get; set; } // Ожидаемый результат
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
                var actual = StrangeSum( testCase.arrayNumber );

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
                    Console.WriteLine( "VALID TEST" );
                }
                else
                {
                    Console.WriteLine( "I N V A L I D   T E S T" );
                }
            }
        }

        static void Main(string[] args)
        {
            //int[] vs = { 10, 0 };
            //Console.WriteLine( StrangeSum(vs).ToString());

            // Тест № 1
            var testCase1 = new TestCase()
            {
                arrayNumber = new[] { 0, 1 },
                Expected = 18,
                ExpectedException = null
            };
            TestNumber( testCase1 );

            // Тест № 2
            var testCase2 = new TestCase()
            {
                arrayNumber = new[] { 0, 1, 3, 4 },
                Expected = 452,
                ExpectedException = null
            };
            TestNumber( testCase2 );

            // Тест № 3
            var testCase3 = new TestCase()
            {
                arrayNumber = new[] { 0, 0, 0, 0 },
                Expected = 324,
                ExpectedException = null
            };
            TestNumber( testCase3 );
        }

        // Асимптотическая сложность функции => O(N^3)
        public static int StrangeSum(int[] inputArray)              // O(1) + O(N^3) = O(N^3)
        {
            int sum = 0;                                                              // O(1)
            for( int i = 0; i < inputArray.Length; i++ )                // O(N * N * N) = O(N^3)
            {
                for( int j = 0; j < inputArray.Length; j++ )            // O(N * N) = O(N^2)
                {
                    for( int k = 0; k < inputArray.Length; k++ )     // O(N) * (O(1) + O(1) + O(1)) = O(N) * 3O(1) = O(N)
                    {
                        int y = 0;                                                      // O(1)
                        if( j != 0 )
                        {
                            y = k / j;                                                   // O(1)
                        }
                        sum += inputArray[ i ] + i + k + j + y;         // O(1)
                    }
                }
            }
            Console.WriteLine( sum );
            return sum;
        }
    }
}
