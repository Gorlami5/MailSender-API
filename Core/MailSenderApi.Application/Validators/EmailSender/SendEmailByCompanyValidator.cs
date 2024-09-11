using FluentValidation;
using MailSenderApi.Application.ViewModels.EmailSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.Validators.EmailSender
{
    public class SendEmailByCompanyValidator : AbstractValidator<SendEmailByCompany_VM>
    {
        public SendEmailByCompanyValidator()
        {
             RuleFor(e => e.CompanyId).NotEmpty().NotNull().WithMessage("Company Id does not null");   
             RuleFor(e => e.TemplateId).NotEmpty().NotNull().WithMessage("Template Id does not null"); 
        }
    }
}
