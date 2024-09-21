using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.Validators.EmailSender
{
    public class EmailSendCustomValidator : ValidationAttribute
    {
        //This validaton can be different assembly class from Company Validators so you may be mistake.If you get error
        //add manuelly assembly for all validator class.
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int id && id > 0)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("ID must be a positive integer and not null.");
        }
    }
}
