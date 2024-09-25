using MailSenderApi.Domain;
using MailSenderApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            modelBuilder.Entity<ReceiverEmail>().HasQueryFilter(rm => rm.Company.IsDeleted == false); //Include
            modelBuilder.Entity<SentMail>().HasQueryFilter(sm => sm.MailTemplate.IsDeleted == false);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var method = typeof(EF).GetMethod("Property", new[] { typeof(object), typeof(string) })
                        ?.MakeGenericMethod(typeof(bool));

                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var propertyMethodCall = Expression.Call(method, parameter, Expression.Constant("IsDeleted"));
                    var filter = Expression.Lambda(Expression.Equal(propertyMethodCall, Expression.Constant(false)), parameter);

                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);

                    modelBuilder.Entity(entityType.ClrType).Property("IsDeleted").HasDefaultValue(false);
                }
            }
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
            UpdateModifiedDate();
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

        private void UpdateModifiedDate()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedDate = DateTime.Now;
                }
            }
        }
    }
}
