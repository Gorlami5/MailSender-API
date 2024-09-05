using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.UseCases.Abstraction
{
    public interface IReceiverEmailWriteUseCase
    {
        Task<int> CreateCompany(ReceiverEmail receiverEmail);
        Task<int> UpdateCompany(ReceiverEmail receiverEmail);
        Task<int> DeleteCompanyById(int id);
        Task<int> DeleteCompany(ReceiverEmail receiverEmail);
        Task<int> CreateCompanies(List<ReceiverEmail> receiverEmail);
    }
}
