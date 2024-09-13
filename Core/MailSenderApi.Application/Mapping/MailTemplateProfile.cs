using AutoMapper;
using MailSenderApi.Application.Dtos;
using MailSenderApi.Application.ViewModels.MailTemplateVM;
using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.Mapping
{
    public class MailTemplateProfile : Profile
    {
        public MailTemplateProfile()
        {
            CreateMap<MailTemplate, MailTemplateReturnDto>();
            CreateMap<MailTemplateReturnDto, MailTemplate>();
            CreateMap<MailTemplate, MailTemplateCreate_VM>();
            CreateMap<MailTemplateCreate_VM, MailTemplate>();
        }
    }
}
