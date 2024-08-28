using MailSenderApi.Application.Repository.ReceiverEmailRepository;
using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Persistance.Repository.ReceiverEmailRepository
{
    public class ReceiverEmailWriteRepository : WriteRepository<ReceiverEmail>,IReceiverEmailWriteRepository
    {
        private readonly APIDbContext _context;
        public ReceiverEmailWriteRepository(APIDbContext apiDbContext) : base(apiDbContext)
        {
            _context = apiDbContext;
        }
    }
}
