using System;
using ClassLibrary;

namespace DLLProject
{
    class ProgramDLLProject
    {
        static void Main(string[] args)
        {
            ClassDLL classDLL = new ClassDLL();
            string text = classDLL.HelloString();
            Console.WriteLine( text );
        }
    }
}
