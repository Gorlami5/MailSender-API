﻿using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.Repository.CompanyRepository
{
    public interface ICompanyReadRepository : IReadRepository<Company>
    {
        Task<Company> GetCompanyByIdAsync(int companyId);
    }
}
