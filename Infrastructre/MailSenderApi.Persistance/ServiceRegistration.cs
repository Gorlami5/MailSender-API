using MailSenderApi.Application.Interfaces;
using MailSenderApi.Application.Mapping;
using MailSenderApi.Application.Repository;
using MailSenderApi.Application.Repository.CompanyRepository;
using MailSenderApi.Application.Repository.MailTemplateRepository;
using MailSenderApi.Application.Repository.ReceiverEmailRepository;
using MailSenderApi.Application.Repository.SentMailRepository;
using MailSenderApi.Application.UseCases.Abstraction;
using MailSenderApi.Application.UseCases.Concrete;
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
            services.AddScoped<ISentMailReadUseCase, SentMailReadUseCase>();
            services.AddScoped<ISentMailWriteUseCase,SentMailWriteUseCase>();
            services.AddScoped<IReceiverEmailReadUseCase, ReceiverEmailReadUseCase>();
            services.AddScoped<IReceiverEmailWriteUseCase, ReceiverEmailWriteUseCase>();
            services.AddScoped<IMailTemplateReadUseCase, MailTemplateReadUseCase>();
            services.AddScoped<IMailTemplateWriteUseCase, MailTemplateWriteUseCase>();
            services.AddScoped<ICompanyWriteUseCase, CompanyWriteUseCase>();
            services.AddScoped<ICompanyReadUseCase, CompanyReadUseCase>();
            services.AddAutoMapper(typeof(CompanyProfile));

        }
    }
}
