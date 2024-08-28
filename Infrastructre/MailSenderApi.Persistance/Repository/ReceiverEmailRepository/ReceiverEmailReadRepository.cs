using MailSenderApi.Application.Repository.ReceiverEmailRepository;
using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Persistance.Repository.ReceiverEmailRepository
{
    public class ReceiverEmailReadRepository: ReadRepository<ReceiverEmail>,IReceiverEmailReadRepository
    {
        private readonly APIDbContext _context;
        public ReceiverEmailReadRepository(APIDbContext apiDbContext) : base(apiDbContext)
        {
            _context = apiDbContext;
        }
    }
}
