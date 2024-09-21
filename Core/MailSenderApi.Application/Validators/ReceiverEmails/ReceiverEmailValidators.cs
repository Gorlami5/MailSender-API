using FluentValidation;
using FluentValidation.Validators;
using MailSenderApi.Application.ViewModels.ReceiverEmailVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.Validators.ReceiverEmails
{
    public class ReceiverEmailValidators : AbstractValidator<ReceiverEmailCreate_VM>
    {
        public ReceiverEmailValidators()
        {
            RuleFor(p => p.Email).NotEmpty().EmailAddress().WithMessage("Invalid Email");
            RuleFor(p => p.CompanyId).NotNull();
            RuleFor(p => p.SendStatus).NotNull();
        }
    }
}
