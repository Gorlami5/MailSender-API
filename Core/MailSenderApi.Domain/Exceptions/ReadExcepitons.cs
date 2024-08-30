using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Domain.Exceptions
{
    public class ReadExcepitons:Exception
    {
        public ReadExcepitons(string message) : base(message)
        {
            
        }
    }
}
