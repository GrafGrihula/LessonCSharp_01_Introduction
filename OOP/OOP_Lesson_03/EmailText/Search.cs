using System;
using System.IO;

namespace EmailText
{
    class Search
    {
        public void ReadText(ref string s)
        {
            string path = @"TextFile1.txt";

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    //s = line.Substring(line.IndexOf('&') + 2);

                    //WriteEmail(line);

                    Console.WriteLine(line);
                }
            }
        }

        public void SearchEmail(ref string s)
        {
            string path = @"TextFile1.txt";

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    s = line.Substring(line.IndexOf('&') + 2);

                    WriteEmail(s);

                    Console.WriteLine(s);
                }
            }
        }

        public void WriteEmail(string s)
        {
            string writePath = @"TextFile2.txt";

            //string text = Console.ReadLine();
            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(s);
            }
        }
    }
}
