﻿using System;
using System.IO;

namespace AppendCurrentTime
{
    /// <summary>
    /// 2. Написать программу, которая при старте дописывает текущее время в файл «startup.txt»
    /// </summary>
    class ProgramAppendCurrentTime
    {
        static void Main(string[] args)
        {
            string filename = "startup.txt";
            File.AppendAllText(filename, Environment.NewLine);
            File.AppendAllText(filename, DateTime.Now.ToString("HH:mm:ss"));
            Console.WriteLine("Текущее время добавлено в текстовый файл.");
            Console.Read();
        }
    }
}
