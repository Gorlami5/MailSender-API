using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Infrastructre
{
    static public class Configuration
    {
        public static string GetEmailHost { get
            {
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/MailSenderApi.API"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetSection("MailSendInformation").GetValue<string>("SenderMailAddress");
            } 
        }
        public static string GetEmailPassword
        {
            get
            {
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/MailSenderApi.API"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetSection("MailSendInformation").GetValue<string>("SenderMailPassword");
            }
        }
    }
}
