using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Domain.Exceptions
{
    public class WriteExceptions:Exception
    {
        public WriteExceptions(string message) : base(message)
        {
            
        }
    }
}
