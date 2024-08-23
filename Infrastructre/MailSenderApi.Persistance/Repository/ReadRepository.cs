using MailSenderApi.Application.Repository;
using MailSenderApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Persistance.Repository
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly APIDbContext _context;
        public ReadRepository(APIDbContext apiDbContext)
        {
            _context = apiDbContext;
        }
        public DbSet<T> Table => _context.Set<T>(); /*{ get => _context.Set<T>(); }*/ // Bir set işlemi yapmama rağmen neden readonly bir yapı kullanıyoruz.

        public IQueryable<T> GetAll()
        {
            return Table;
        }

        public IQueryable<T> GetWhereList(Expression<Func<T, bool>> method)
        {
           return Table.Where(method);
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await Table.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<T> GetSingle(Expression<Func<T, bool>> method)
        {
            return await Table.FirstOrDefaultAsync(method);
        }
    }
}
