using FluentValidation;
using MailSenderApi.Application.ViewModels.CompanyVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.Validators.Company
{
    public class CompanyUpdateValidators : AbstractValidator<CompanyUpdate_VM>
    {
        public CompanyUpdateValidators()
        {
            RuleFor(p => p.Address).NotEmpty().NotNull().WithMessage("Address cant be null");
            RuleFor(p => p.CompanyName).NotEmpty().NotNull().WithMessage("Company Name cant be null");
            RuleFor(p => p.Location).NotEmpty().NotNull().WithMessage("Company location cant be null");
            RuleFor(p => p.PhoneNumber).NotEmpty().NotNull().WithMessage("Phone Number cant be null").Matches(@"^(?:\+90|0)[5][0-9]{2}[0-9]{3}[0-9]{2}[0-9]{2}$")
            .WithMessage("Please enter accurate phone number");
        }
    }
}
