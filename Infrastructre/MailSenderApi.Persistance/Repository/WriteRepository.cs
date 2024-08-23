using MailSenderApi.Application.Repository;
using MailSenderApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Persistance.Repository
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly APIDbContext _context;
        public WriteRepository(APIDbContext apiDbContext)
        {
            _context = apiDbContext;
        }
        public DbSet<T> Table { get => _context.Set<T>(); } 

        public async Task<bool> AddAsync(T entity)
        {
           EntityEntry entityEntry =  await Table.AddAsync(entity);
           return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entity)
        {
           await Table.AddRangeAsync(entity);
           return true;
        }

        public bool Delete(T entity)
        {
            EntityEntry entityEntry =  Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool Delete(int entityId)
        {
            T removedEntity =  Table.FirstOrDefault(r => r.Id == entityId);
            EntityEntry entityEntry = Table.Remove(removedEntity);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool Update(T entity)
        {
            EntityEntry entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
        public Task<int> SaveChangesAsync2()
        {
            return _context.SaveChangesAsync();
        }
    }
}
