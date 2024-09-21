
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.Constants
{
    //If you use Domain Service you should not identify to Application Layer
    static public class ErrorMessages
    {
        static public string UnexpectedFault = "Unexpected Fault";
        static public string NotFound = "Company Not Found";
        static public string AddFault = "Add Fault";
        static public string UpdateFault = "Update Fault";
        static public string DeleteFault = "Delete Fault";
        static public string SaveFault = "SaveFault";
        static public string MailSendFault = "Mail send fault";

    }
}
