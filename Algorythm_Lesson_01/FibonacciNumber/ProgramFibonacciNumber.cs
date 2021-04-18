using System;

namespace FibonacciNumber
{
    class ProgramFibonacciNumber
    {
        public class TestCase
        {
            public int index { get; set; } // Значение переменной
            public int Expected { get; set; } // Ожидаемый результат
            public Exception ExpectedException { get; set; } // Ошибка
        }

        static void TestIndex(TestCase testCase)
        {
            try
            {
                var actual = FibonacciCalcRecurs( testCase.index );

                if( actual == testCase.Expected )
                    Console.WriteLine( "VALID TEST RECURS" );
                else Console.WriteLine( "I N V A L I D   T E S T  R E C U R S" );
            }
            catch/*(Exception ex)*/
            {
                if( testCase.ExpectedException != null )
                    Console.WriteLine( "VALID TEST RECURS" );
                else Console.WriteLine( "I N V A L I D   T E S T  R E C U R S" );
            }

            try
            {
                var actual = FibonacciCalcCycle( testCase.index );

                if( actual == testCase.Expected )
                    Console.WriteLine( "VALID TEST CYCLE\n" );
                else Console.WriteLine( "I N V A L I D   T E S T  C Y C L E\n" );
            }
            catch/*(Exception ex)*/
            {
                if( testCase.ExpectedException != null )
                    Console.WriteLine( "VALID TEST CYCLE\n" );
                else Console.WriteLine( "I N V A L I D   T E S T  C Y C L E\n" );
            }
        }

        static void Main(string[] args)
        {
            //int index = 0;
            //Console.Write("Введите значение для вычисления числа Фибоначчи: ");
            //index = Int32.Parse(Console.ReadLine());
            //Console.WriteLine( $"Число Фибоначчи (РЕКУРСИЯ) для значения n={index} равно {FibonacciCalcRecurs( index )}" );
            //Console.WriteLine( $"Число Фибоначчи (ЦИКЛ) для значения n={index} равно {FibonacciCalcCycle( index )}" );

            // Тест № 1
            var testCase1 = new TestCase()
            {
                index = 0,
                Expected = 0,
                ExpectedException = null
            };
            TestIndex( testCase1 );

            // Тест № 2
            var testCase2 = new TestCase()
            {
                index = 1,
                Expected = 1,
                ExpectedException = null
            };
            TestIndex( testCase2 );

            // Тест № 3
            var testCase3 = new TestCase()
            {
                index = 2,
                Expected = 1,
                ExpectedException = null
            };
            TestIndex( testCase3 );

            // Тест № 4
            var testCase4 = new TestCase()
            {
                index = 3,
                Expected = 2,
                ExpectedException = null
            };
            TestIndex( testCase4 );

            // Тест № 5
            var testCase5 = new TestCase()
            {
                index = 6,
                Expected = 8,
                ExpectedException = null
            };
            TestIndex( testCase5 );        

            Console.Read();
        }

        #region Блок вычисления числа Фибоначчи РЕКУРСИЕЙ
        static int FibonacciCalcRecurs(int index)
        {
            return FibonacciCalcRecurs( index, out _);
        }

        static int FibonacciCalcRecurs(int index, out int F1)
        {
            int indexAbs = Math.Abs( index );
            F1 = 0;
            if( indexAbs == 0 )
            {
                return 0;
            }
            else if( indexAbs == 1 )
            {
                return 1;
            }
            else
            {
                int F2;
                F1 = FibonacciCalcRecurs( indexAbs - 1, out F2 );
                return Math.Sign( index ) * (F1 + F2);
            }
        }
        #endregion

        #region Блок вычисления числа Фибоначчи ЦИКЛОМ
        static int FibonacciCalcCycle(int index)
        {
            int fibonacci = 0;
            int first = 0;
            int second = 1;
            if( Math.Abs( index ) == 1 )
            {
                fibonacci = second;
            }               

            for( int i = 0; i < Math.Abs( index ) - 1; i++ )
            {
                fibonacci = first + second;
                first = second;
                second = fibonacci;
            }

            return Math.Sign( index ) * fibonacci;
        }
        #endregion
    }
}
