using AutoMapper;
using MailSenderApi.Application.Constants;
using MailSenderApi.Application.Dtos;
using MailSenderApi.Application.Repository.ReceiverEmailRepository;
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
    public class ReceiverEmailReadUseCase : IReceiverEmailReadUseCase
    {
        private readonly IReceiverEmailReadRepository _receiverEmailReadRepository;
        private readonly IMapper _mapper;
        public ReceiverEmailReadUseCase(IReceiverEmailReadRepository receiverEmailReadRepository, IMapper mapper)
        {
           _receiverEmailReadRepository = receiverEmailReadRepository;
           _mapper = mapper;
        }
        public List<ReceiverEmailReturnDto> GetAllReceiverEmails()
        {
                
                var receiverEmails = _receiverEmailReadRepository.GetAll(false);

                if(receiverEmails.ToList().Count == 0)
                {
                    throw new ReadExcepitons(ErrorMessages.NotFound);
                }
                var receiverEmailsDtoList = _mapper.Map<List<ReceiverEmailReturnDto>>(receiverEmails);
                return receiverEmailsDtoList;

        }

        public List<ReceiverEmailReturnDto> GetAllReceiverEmailsByCompanyId(int id)
        {     
            
                var GetAllReceiverEmails = _receiverEmailReadRepository.GetWhereList(e => e.CompanyId == id);
                if (GetAllReceiverEmails.ToList().Count == 0)
                {
                    throw new ReadExcepitons(ErrorMessages.NotFound);
                }
                var receiverEmailsDtoList = _mapper.Map<List<ReceiverEmailReturnDto>>(GetAllReceiverEmails);
                return receiverEmailsDtoList;
        }

        public async Task<ReceiverEmailReturnDto> GetReceiverEmail(int id)
        {
            
                var email = await _receiverEmailReadRepository.GetByIdAsync(id);
                if (email == null)
                {
                    throw new ReadExcepitons(ErrorMessages.NotFound);
                }
                var dto = _mapper.Map<ReceiverEmailReturnDto>(email);
                return dto;
         
        }

        public async Task<ReceiverEmailReturnDto> GetReceiverEmailByEmail(string email)
        {
           
                var receiverEmail = await _receiverEmailReadRepository.GetSingle(e => e.Email.Equals(email));
                if (receiverEmail == null)
                {
                    throw new ReadExcepitons(ErrorMessages.NotFound);
                }
                var dto = _mapper.Map<ReceiverEmailReturnDto>(receiverEmail);
                return dto;          
           
        }
    }
}
