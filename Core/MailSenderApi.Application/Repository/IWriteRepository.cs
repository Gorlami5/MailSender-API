using MailSenderApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.Repository
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
       Task<bool> AddAsync(T entity);

       Task<bool> AddRangeAsync(List<T> entity);

       bool Update(T entity);

       bool Delete(T entity);

       bool Delete(int entityId);
       Task<int> SaveChangesAsync();
    }
}
