using MailSenderApi.Application.Mapping;
using MailSenderApi.Application.UseCases.Abstraction;
using MailSenderApi.Application.UseCases.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application
{
    static public class CoreServiceRegistration
    {
        static public void AddCoreServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<ICompanyWriteUseCase,CompanyWriteUseCase>();
            services.AddScoped<ICompanyReadUseCase, CompanyReadUseCase>();
            services.AddScoped<IEmailSenderUseCase, EmailSenderUseCase>();
            services.AddAutoMapper(typeof(CompanyProfile));
        }
    }
}
