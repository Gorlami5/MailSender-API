using MailSenderApi.Application.Constants;
using MailSenderApi.Application.Repository.MailTemplateRepository;
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
    public class MailTemplateReadUseCase : IMailTemplateReadUseCase
    {
        private readonly IMailTemplateReadRepository _repository;
        public MailTemplateReadUseCase(IMailTemplateReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MailTemplate>> GetAllMailTemplates()
        {          
                var templates = _repository.GetAll();
                if(templates == null) 
                {
                    throw new ReadExcepitons(ErrorMessages.NotFound);
                }
                return await templates.ToListAsync();      

        }
    }
}
