using AutoMapper;
using MailSenderApi.Application.Dtos;
using MailSenderApi.Application.ViewModels.ReceiverEmailVM;
using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.Mapping
{
    public class ReceiverEmailProfile : Profile
    {
        public ReceiverEmailProfile()
        {
            CreateMap<ReceiverEmail, ReceiverEmailReturnDto>();
            CreateMap<ReceiverEmailReturnDto, ReceiverEmail>();
            CreateMap<ReceiverEmail, ReceiverEmailCreate_VM>();
            CreateMap<ReceiverEmailCreate_VM,ReceiverEmail>();
        }
    }
}
