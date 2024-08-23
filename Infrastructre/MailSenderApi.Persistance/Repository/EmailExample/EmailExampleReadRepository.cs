using MailSenderApi.Application.Repository;
using MailSenderApi.Application.Repository.EmailExample;
using MailSenderApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Persistance.Repository.EmailExample
{
    public class EmailExampleReadRepository : ReadRepository<Email>,IEmailExampleReadRepository
    {
        private readonly APIDbContext _context;
        public EmailExampleReadRepository(APIDbContext apiDbContext):base(apiDbContext)
        {
            _context = apiDbContext;
        }
        
        public async void a()
        {
            var an = GetAll();
        }
       
    }
}
