using FluentValidation;
using MailSenderApi.Application.ViewModels.EmailSenderVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.Validators.EmailSender
{
    public class SendEmailByAddressValidator : AbstractValidator<SendEmailByAddress_VM>
    {
        public SendEmailByAddressValidator()
        {
            RuleFor( e => e.Email).NotNull().NotEmpty().EmailAddress().WithMessage("Unvalid email");
            RuleFor(e => e.MailTemplateId).NotNull().NotEmpty().WithMessage("Template Id does not null");
        }
    }
}
