using MailSenderApi.Application.Interfaces;
using MailSenderApi.Application.UseCases.Abstraction;
using MailSenderApi.Application.UseCases.Concrete;
using MailSenderApi.Infrastructre.Email;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Infrastructre
{
    public static class InfrastructreServiceRegistration
    {
        static public void AddCoreServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IEmailSenderUseCase, EmailSenderUseCase>();
        }
    }
}
