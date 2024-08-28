using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Persistance
{
    static public class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager conf = new ConfigurationManager();
                conf.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/MailSenderApi.API"));
                conf.AddJsonFile("appsettings.json");                
                return conf.GetConnectionString("DefaultConnectionString");  
            }
            
           
        }
    }
}
