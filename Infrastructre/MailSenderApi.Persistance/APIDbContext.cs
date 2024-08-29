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
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SoftDelete();
            return await base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges()
        {
            SoftDelete();
            return base.SaveChanges();
        }
        private void SoftDelete()
        {
            var entities = ChangeTracker.Entries()
                        .Where(e => e.State == EntityState.Deleted);
            foreach (var entity in entities)
            {
                if(entity.Entity is BaseEntity)
                {
                    entity.State = EntityState.Modified;
                    var baseEntity = (BaseEntity)entity.Entity;
                    baseEntity.IsDeleted = true;
                }
            }
        }
    }
}
