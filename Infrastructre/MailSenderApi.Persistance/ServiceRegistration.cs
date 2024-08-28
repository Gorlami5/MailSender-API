using MailSenderApi.Application.Repository;
using MailSenderApi.Application.Repository.CompanyRepository;
using MailSenderApi.Application.Repository.MailTemplateRepository;
using MailSenderApi.Application.Repository.ReceiverEmailRepository;
using MailSenderApi.Application.Repository.SentMailRepository;
using MailSenderApi.Persistance.Repository;
using MailSenderApi.Persistance.Repository.CompanyRepository;
using MailSenderApi.Persistance.Repository.MailTemplateRepository;
using MailSenderApi.Persistance.Repository.ReceiverEmailRepository;
using MailSenderApi.Persistance.Repository.SentMailRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Persistance
{
    public static class ServiceRegistration 
    {
      public static void AddRegistration(this IServiceCollection services)
        {
            services.AddDbContext<APIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<IReceiverEmailReadRepository, ReceiverEmailReadRepository>();
            services.AddScoped<IReceiverEmailWriteRepository, ReceiverEmailWriteRepository>();
            services.AddScoped<ICompanyReadRepository, CompanyReadRepository>();
            services.AddScoped<ICompanyWriteRepository, CompanyWriteRepository>();
            services.AddScoped<ISentMailReadRepository, SentMailReadRepository>();
            services.AddScoped<ISentMailWriteRepository, SentMailWriteRepository>();
            services.AddScoped<IMailTemplateWriteRepository, MailTemplateWriteRepository>();
            services.AddScoped<IMailTemplateReadRepository, MailTemplateReadRepository>();

        }
    }
}
