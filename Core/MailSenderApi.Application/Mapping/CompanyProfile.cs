using AutoMapper;
using MailSenderApi.Application.Dtos;
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
        }
    }
}
