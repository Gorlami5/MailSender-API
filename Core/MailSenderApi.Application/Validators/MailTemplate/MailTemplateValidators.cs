using FluentValidation;
using MailSenderApi.Application.ViewModels.MailTemplateVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.Validators.MailTemplate
{
    public class MailTemplateValidators : AbstractValidator<MailTemplateCreate_VM>
    {
        public MailTemplateValidators()
        {
            RuleFor(p => p.Topic).NotEmpty().MaximumLength(20).WithMessage("Invalid Topic");
            RuleFor(p => p.Body).NotEmpty().MaximumLength(250).WithMessage("Invalid Body");
        }
    }
}
