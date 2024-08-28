using MailSenderApi.Domain;
using MailSenderApi.Domain.Entities;
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
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ReceiverEmail> ReceiverEmails { get; set; }
        public DbSet<SentMail> SentMails { get; set; }
        public DbSet<MailTemplate> MailTemplates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseEntity>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.Entity<BaseEntity>().Property(e => e.IsDeleted).HasDefaultValue(false);
            base.OnModelCreating(modelBuilder); 
        }
    }
}
