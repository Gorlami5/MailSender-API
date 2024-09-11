using MailSenderApi.Application.Constants;
using MailSenderApi.Application.Repository.SentMailRepository;
using MailSenderApi.Application.UseCases.Abstraction;
using MailSenderApi.Domain.Entities;
using MailSenderApi.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.UseCases.Concrete
{
    public class SentMailReadUseCase : ISentMailReadUseCase
    {
        private readonly ISentMailReadRepository _repository;
        public SentMailReadUseCase(ISentMailReadRepository repository)
        {
                _repository = repository;
        }
        public async Task<List<SentMail>> GetAllSentMail()
        {
           
                var sentMails = _repository.GetAll();
                sentMails.Include(s => s.MailTemplate);
                if (sentMails == null)
                {
                    throw new ReadExcepitons(ErrorMessages.NotFound);
                }
                return await sentMails.ToListAsync();
            
                      
        }
        public async Task<List<SentMail>> GetSentMailsListByCompanyId(int companyId)
        {
           
                var sentMails = _repository.GetWhereList(s => s.CompanyId == companyId);
                sentMails.Include(s => s.MailTemplate);
                if (sentMails == null)
                {
                    throw new ReadExcepitons(ErrorMessages.NotFound);
                }
                return await sentMails.ToListAsync();
        }
    }
}
