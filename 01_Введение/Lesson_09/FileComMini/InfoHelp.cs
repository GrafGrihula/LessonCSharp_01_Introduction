using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    class InfoHelp
    {
        public void HelpText()
        {
            using(StreamReader streamReader = File.OpenText( "Help.txt" ) )
            {
                string input = null;
                while((input = streamReader.ReadLine()) != null )
                {
                    Console.WriteLine( input );
                }
                Console.WriteLine( "Для закрытия СПРАВКИ нажмите Esc" );
            }

            ConsoleKeyInfo userKey = Console.ReadKey( true );
            switch( userKey.Key )
            {
                case ConsoleKey.Escape:
                    break;
                default:
                    HelpText();
                    break;
            }
        }        
    }
}
