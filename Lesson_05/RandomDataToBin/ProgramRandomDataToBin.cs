using System;
using System.Collections.Generic;
using System.IO;

namespace RandomDataToBin
{
    /// <summary>
    /// 3. Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл
    /// </summary>
    class ProgramRandomDataToBin
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите через пробел произвольный набор числе в диапазоне 0...255: ");
            string text = Console.ReadLine(); // Сохраняем текст в переменную
            SaveNumberToBin(text);
            Console.Read();
        }

        /// <summary>
        /// Метод преобразования строки в массив байт
        /// </summary>
        /// <param name="text">строка с набором чисел</param>
        private static void SaveNumberToBin(string text)
        {
            string[] dataStringArray = text.Split(' '); 
            List<byte> textList = new List<byte>();
            foreach(string s in dataStringArray)
            {
                textList.Add(byte.Parse(s));
            }
            byte[] byteArray = textList.ToArray();
            File.WriteAllBytes("dataBytes.bin", byteArray);
        }
    }
}
