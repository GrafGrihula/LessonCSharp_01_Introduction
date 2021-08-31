using System;

namespace BinaryFind
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = { 1, 2, 3, 4, 55, 56, 74, 245, 567 };
            int[] expectedIndex = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            Console.WriteLine( "Введите искомое число" );

            int searchValue = int.Parse( Console.ReadLine() );
            int index = BinarySearch( inputArray, searchValue );
            if( index >= 0 )
            {
                if( index == expectedIndex[ index ] )
                {
                    Console.WriteLine( "Всё верно!" );
                    Console.WriteLine( "Искомое число является " + (index + 1) + "-м по счёту" );
                }
                else
                {
                    Console.WriteLine( "Поиск работает НЕ ВЕРНО!" );
                }
            }
            else
            {
                Console.WriteLine( "Такое число в массиве отсутствует." );
            }
        }

        public static int BinarySearch(int[] inputArray, int searchValue) //------- O(N*Log2(N))
        {
            int min = 0;
            int max = inputArray.Length - 1; //------------------------------------- O(1)
            while( min <= max ) //-------------------------------------------------- O(N*Log2(N))
            {
                int mid = (min + max) / 2;  //---------------------------------------- O(1)
                if( searchValue == inputArray[ mid ] )  //--------------------------- O(2N) = O(N)
                {
                    return mid;
                }
                else if( searchValue < inputArray[ mid ] )  //------------------------ O(N)
                {
                    max = mid - 1; //-------------------------------------------------- O(1)
                }
                else
                {
                    min = mid + 1; //-------------------------------------------------- O(1)
                }
            }
            return -1;
        }
    }
}
