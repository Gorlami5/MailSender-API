using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Domain.Exceptions
{
    public class ServicesException : Exception
    {
        public ServicesException(string message) : base(message)
        {
            
        }
    }
}
