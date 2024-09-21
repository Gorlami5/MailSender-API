using MailSenderApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.Repository
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true); 
        Task<T> GetByIdAsync(int id, bool tracking = true);
        IQueryable<T> GetWhereList(Expression<Func<T,bool>> method, bool tracking = true); 
        Task<T> GetSingle(Expression<Func<T, bool>> method, bool tracking = true);
    }
}
