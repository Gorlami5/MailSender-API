using AutoMapper;
using MailSenderApi.Application.Constants;
using MailSenderApi.Application.Dtos;
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
        private readonly IMapper _mapper;
        public MailTemplateReadUseCase(IMailTemplateReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<MailTemplateReturnDto>> GetAllMailTemplates()
        {
            var templates = _repository.GetAll();
            var enumerableTemplates = await templates.ToListAsync();
            if (enumerableTemplates.Count == 0)
            {
                throw new ReadExcepitons(ErrorMessages.NotFound);
            }
            var mappedTemplates = _mapper.Map<List<MailTemplateReturnDto>>(templates);

            return mappedTemplates;

        }
    }
}
