using MailSenderApi.Application.Constants;
using MailSenderApi.Application.Repository.ReceiverEmailRepository;
using MailSenderApi.Domain.Entities;
using MailSenderApi.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<ReceiverEmail>> GetAllReceiverEmails()
        {
            var GetAllReceiverEmails = GetAll(false);
            return await GetAllReceiverEmails.ToListAsync();
        }
        public async Task<ReceiverEmail> GetReceiverEmail(int id)
        {
            var email = await GetByIdAsync(id);
            return email;
        }
        public async Task<ReceiverEmail> GetReceiverEmailByEmail(string email)
        {
            var receiverEmail = await GetSingle(e => e.Email.Equals(email));
            return receiverEmail;
        }

        public async Task<List<ReceiverEmail>> GetAllReceiverEmailsByCompanyId(int id)
        {
            var GetAllReceiverEmails = GetWhereList(e => e.CompanyId ==id);
            return await GetAllReceiverEmails.ToListAsync();
        }

    }
}
