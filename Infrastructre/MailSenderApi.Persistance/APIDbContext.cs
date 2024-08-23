using MailSenderApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Persistance
{
    public class APIDbContext:DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) { }
        public DbSet<Email> Emails { get; set; }
    }
}
