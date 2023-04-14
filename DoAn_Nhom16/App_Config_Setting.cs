using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DoAn_Nhom16
{
    class App_Config_Setting
    {
        Configuration config;
        public App_Config_Setting()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }
        public string getConnectionString(string nameCS)
        {
            return config.ConnectionStrings.ConnectionStrings[nameCS].ConnectionString;
        }
        public void setConnectionString(string nameCS, string valueCS)
        {
            config.ConnectionStrings.ConnectionStrings[nameCS].ConnectionString = valueCS;
            config.ConnectionStrings.ConnectionStrings[nameCS].ProviderName = "System.Data.SqlClient";
            config.Save(ConfigurationSaveMode.Modified);
        }
        public string getValue(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }
        public void setValue(string name, string values)
        {
            ConfigurationManager.AppSettings[name]=values;
        }
    }
}
