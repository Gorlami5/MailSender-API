using AutoMapper;
using MailSenderApi.Application.Constants;
using MailSenderApi.Application.Repository.CompanyRepository;
using MailSenderApi.Application.Repository.MailTemplateRepository;
using MailSenderApi.Application.Repository.SentMailRepository;
using MailSenderApi.Application.UseCases.Abstraction;
using MailSenderApi.Application.ViewModels.MailTemplateVM;
using MailSenderApi.Domain.Entities;
using MailSenderApi.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MailSenderApi.Application.UseCases.Concrete
{
    public class MailTemplateWriteUseCase : IMailTemplateWriteUseCase
    {
        private readonly IMailTemplateWriteRepository _repository;
        private readonly IMapper _mapper;
        public MailTemplateWriteUseCase(IMailTemplateWriteRepository repository,IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task CreateMailTemplate(MailTemplateCreate_VM mailTemplate)
        {
                var template = _mapper.Map<MailTemplate>(mailTemplate);
                var returnedValue = await _repository.AddAsync(template);
                if (returnedValue is false)
                {
                    throw new WriteExceptions(ErrorMessages.AddFault);
                }
                var saveAsync = await _repository.SaveChangesAsync();
                if (saveAsync < 1)
                {
                    throw new WriteExceptions(ErrorMessages.SaveFault);
                }
            
        }

        public async Task DeleteMailTemplate(MailTemplate mailTemplate)
        {
            
                var returnedValue = _repository.Delete(mailTemplate);
                if (returnedValue is false)
                {
                    throw new WriteExceptions(ErrorMessages.DeleteFault);
                }
                var saveAsync = await _repository.SaveChangesAsync();
                if (saveAsync < 1)
                {
                    throw new WriteExceptions(ErrorMessages.SaveFault);
                }

        }

        public async Task DeleteMailTemplateById(int id)
        {
           
                var returnedValue = _repository.Delete(id);
                if (returnedValue is false)
                {
                    throw new WriteExceptions(ErrorMessages.DeleteFault);
                }
                var saveAsync = await _repository.SaveChangesAsync();
                if (saveAsync < 1)
                {
                    throw new WriteExceptions(ErrorMessages.SaveFault);
                }           
        }

        public async Task UpdateMailTemplate(MailTemplate mailTemplate)
        {
           
                var returnedValue = _repository.Update(mailTemplate);
                if (returnedValue is false)
                {
                    throw new WriteExceptions(ErrorMessages.UpdateFault);
                }
                var saveAsync = await _repository.SaveChangesAsync();
                if (saveAsync < 1)
                {
                    throw new WriteExceptions(ErrorMessages.SaveFault);
                }           
        }
    }
}
