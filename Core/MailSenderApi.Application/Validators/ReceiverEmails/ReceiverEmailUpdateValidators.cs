using FluentValidation;
using MailSenderApi.Application.ViewModels.ReceiverEmailVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.Validators.ReceiverEmails
{
    public class ReceiverEmailUpdateValidators : AbstractValidator<ReceiverEmailUpdate_VM>
    {
        public ReceiverEmailUpdateValidators()
        {

            RuleFor(p => p.Email).NotEmpty().EmailAddress().WithMessage("Invalid Email");
            RuleFor(p => p.SendStatus).NotNull();

        }
    }
}
