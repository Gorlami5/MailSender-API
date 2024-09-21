using AutoMapper;
using MailSenderApi.Application.Dtos;
using MailSenderApi.Application.ViewModels.CompanyVM;
using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.Mapping
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyReturnDto>();
            CreateMap<CompanyReturnDto, Company>();
            CreateMap<CompanyCreate_VM, Company>().ForMember(dest => dest.ReceiverEmails,opt => opt.MapFrom(a => a.ReceiverEmails));
            CreateMap<Company, CompanyCreate_VM>().ForMember(dest => dest.ReceiverEmails, opt => opt.MapFrom(a => a.ReceiverEmails));
            CreateMap<Company, CompanyUpdate_VM>();
            CreateMap<CompanyUpdate_VM, Company>();

        }
    }
}
