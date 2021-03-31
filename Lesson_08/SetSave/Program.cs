using System;
using System.Configuration;
using System.Collections.Specialized;

namespace SetSave
{
    class Program
    {
        static void Main(string[] args)
        {
            string sAttr;

            // Read a particular key from the config file 
            sAttr = ConfigurationManager.AppSettings.Get( "Key0" );
            Console.WriteLine( "The value of Key0: " + sAttr );

            // Read all the keys from the config file
            NameValueCollection sAll;
            sAll = ConfigurationManager.AppSettings;

            foreach( string s in sAll.AllKeys )
                Console.WriteLine( "Key: " + s + " Value: " + sAll.Get( s ) );
            Console.ReadLine();

            Console.WriteLine("Введите имя: ");
            sAttr = Console.ReadLine();
            ConfigurationManager.AppSettings.Set( "Key0", sAttr );

            Class1 class1 = new Class1();
            //class1.set_connection( sAttr );

            class1.AddOrUpdateAppSettings( "Key0", sAttr );

        }

        
    }
}
