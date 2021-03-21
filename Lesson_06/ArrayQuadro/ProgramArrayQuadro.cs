using System;

namespace ArrayQuadro
{
    /// <summary>
    /// 
    /// Сразу скажу, что код не мой, а из разбора ДЗ.
    /// Изучаю по примерам)))
    /// Единственное, что мне не совсем понятно, так это ": Exception":
    /// class MyArrayDataException : Exception
    /// class MyArraySizeExeption : Exception
    /// 
    /// Как я понял, это наследование класса  "Exception" с возможностью 
    /// его модификации (дополнения).
    /// Вопрос: а для чего это в данном случае?
    /// 
    /// </summary>
    class ProgramArrayQuadro
    {
        static void Main(string[] args)
        {
            int sum = 0;
            Random random = new Random();
            string[,] sArray = new string[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    sArray[i, j] = random.Next(1, 50).ToString();
                }
            }

            //sArray[2, 3] = "sdf";

            try
            {
                sum = sumArray(sArray);
            }
            catch (MyArraySizeExeption e)
            {
                Console.WriteLine(e.StackTrace);
            }
            catch (MyArrayDataException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            Console.WriteLine(sum);
        }

        public static int sumArray(string[,] sArray)
        {
            int sum = 0;
            if (sArray.GetLength(0) != 4) throw new MyArraySizeExeption();
            for (int i = 0; i < sArray.GetLength(0); i++)
            {
                for (int j = 0; j < sArray.GetLength(1); j++)
                {
                    try
                    {
                        sum += Int32.Parse(sArray[i, j]);
                    }
                    catch (Exception e)
                    {
                        throw new MyArrayDataException(i, j);
                    }

                }
            }
            return sum;
        }
    }
}
