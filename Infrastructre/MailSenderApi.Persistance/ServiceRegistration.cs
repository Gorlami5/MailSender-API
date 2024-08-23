using MailSenderApi.Application.Repository;
using MailSenderApi.Application.Repository.EmailExample;
using MailSenderApi.Persistance.Repository;
using MailSenderApi.Persistance.Repository.EmailExample;
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
            services.AddDbContext<APIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString()));
            services.AddScoped<IEmailExampleWriteRepository,EmailExampleWriteRepository>();
            services.AddScoped<IEmailExampleReadRepository, EmailExampleReadRepository>();
        }
    }
}
