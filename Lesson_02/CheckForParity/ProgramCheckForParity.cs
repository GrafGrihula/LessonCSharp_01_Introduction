using System;

namespace CheckForParity
{
    class ProgramCheckForParity
    {
        static void Main(string[] args)
        {
            string shopName = "    ООО 'ДЕКАДА'";
            int unp = 190960352;
            int ksa = 110017629;
            DateTime checkDateAndTime = new DateTime(2018, 01, 10, 13, 30, 15);
            float checkSum = 1100.05f;
            int checkNum = 0000216;
            string burdaCharUp = "    KJH2356G435H";
            string burdaCharDown = "    DFG62HG7D2H9";
            string strikhKod01 = "|| | |||  ||| |||| |";
            string strikhKod02 = "|| | |||  ||| |||| |";
            string strikhKod03 = "|| | |||  ||| |||| |";

            Console.WriteLine(shopName);
            Console.WriteLine("УНП        {0}", unp);
            Console.WriteLine("РН КСА     {0}", ksa);
            Console.WriteLine("М00011326 {0}", checkDateAndTime.ToShortDateString());
            Console.WriteLine();
            Console.WriteLine(" ПЛАТЕЖНЫЙ ДОКУМЕНТ");
            Console.WriteLine("    ЧЕК ПРОДАЖИ");
            Console.WriteLine();
            Console.WriteLine("01С         *{0}", checkSum);
            Console.WriteLine("ИТОГО НАЛИЧНЫМИ");
            Console.WriteLine("            *{0}", checkSum);
            Console.WriteLine("КАССИР1");
            Console.WriteLine("№{0}           {1}", checkNum, checkDateAndTime.ToShortTimeString());
            Console.WriteLine(burdaCharUp);
            Console.WriteLine(burdaCharDown);
            Console.WriteLine(strikhKod01);
            Console.WriteLine(strikhKod02);
            Console.WriteLine(strikhKod03);

            Console.Read();
        }
    }
}
