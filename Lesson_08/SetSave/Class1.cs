using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SetSave
{
    class Class1
    {
        public void set_connection(string constr)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration( ConfigurationUserLevel.None );
            config.ConnectionStrings.ConnectionStrings[ "Key0" ].ConnectionString = constr;
            config.Save( ConfigurationSaveMode.Modified, true );
            ConfigurationManager.RefreshSection( "appSettings" );
        }

        public void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration( ConfigurationUserLevel.None );
                var settings = configFile.AppSettings.Settings;
                if( settings[ key ] == null )
                {
                    settings.Add( key, value );
                }
                else
                {
                    settings[ key ].Value = value;
                }
                configFile.Save( ConfigurationSaveMode.Modified );
                ConfigurationManager.RefreshSection( configFile.AppSettings.SectionInformation.Name );
            }
            catch( ConfigurationErrorsException )
            {
                Console.WriteLine( "Error writing app settings" );
            }
        }
    }
}
