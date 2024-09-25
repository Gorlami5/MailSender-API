
using MailSenderApi.Application.Constants;
using MailSenderApi.Application.Interfaces;
using MailSenderApi.Application.Repository.MailTemplateRepository;
using MailSenderApi.Application.Repository.ReceiverEmailRepository;
using MailSenderApi.Application.Repository.SentMailRepository;
using MailSenderApi.Application.UseCases.Abstraction;
using MailSenderApi.Domain.Entities;
using MailSenderApi.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MailSenderApi.Application.UseCases.Concrete
{
    public class EmailSenderUseCase : IEmailSenderUseCase
    {
        private readonly IEmailSender _emailSender;
        private readonly IReceiverEmailReadRepository _receiverEmailReadRepository;
        private readonly IMailTemplateReadRepository _mailTemplateReadRepository;
        private readonly ISentMailWriteUseCase _sentMailWriteUseCase;

        public EmailSenderUseCase(IEmailSender emailSender,
                                  IReceiverEmailReadRepository receiverEmailReadRepository,
                                  IMailTemplateReadRepository mailTemplateReadRepository,
                                  ISentMailWriteUseCase sentMailWriteUseCase)
        {

            _emailSender = emailSender;
            _receiverEmailReadRepository = receiverEmailReadRepository;
            _mailTemplateReadRepository = mailTemplateReadRepository;
            _sentMailWriteUseCase = sentMailWriteUseCase;
        }
        public async Task SendEmailByCompanyId(int templateId,int companyId)
        {
            List<string> filteredByCompanyIdReceiverEmailList = new List<string>();
            List<SentMail> sentMails = new List<SentMail>();
            var mailTemplate = await _mailTemplateReadRepository.GetSingle(t => t.Id == templateId);
            if (mailTemplate == null)
            {
                throw new ServicesException(ErrorMessages.NotFound);
            }
            var body = CreateEmailBody(mailTemplate.Body);

            var receiverEmails = await _receiverEmailReadRepository.GetWhereList(r => r.CompanyId == companyId).ToListAsync();
            if (receiverEmails != null)
            {
                foreach (var receiverEmail in receiverEmails)
                {
                    filteredByCompanyIdReceiverEmailList.Add(receiverEmail.Email);
                }
            }
            var initSentMail = new SentMail()
            {
                MailTemplateId = mailTemplate.Id,
                CompanyId = companyId,

            };
            foreach (var receiverEmail in filteredByCompanyIdReceiverEmailList)
            {
                initSentMail.ToEmail = receiverEmail;
                sentMails.Add(initSentMail);
            }

             //Relocate with SendEmailAsync so true logic
            await _emailSender.SendEmailAsync(filteredByCompanyIdReceiverEmailList, mailTemplate.Topic, body);
            await _sentMailWriteUseCase.CreateSentMails(sentMails);

        }
        public async Task SendAllEmails(int templateId)
        {
            try
            {
                List<string> allReceiverEmailsList = new List<string>();
                List<SentMail> sentMails = new List<SentMail>();

                var mailTemplate = await _mailTemplateReadRepository.GetSingle(t => t.Id == templateId);
                if(mailTemplate == null)
                {
                    throw new ServicesException(ErrorMessages.NotFound);
                }
                var body = CreateEmailBody(mailTemplate.Body);


                var allReceiverEmails = await _receiverEmailReadRepository.GetAll().ToListAsync();
                if(allReceiverEmails != null)
                {
                    foreach (var receiverEmail in allReceiverEmails)
                    {
                        allReceiverEmailsList.Add(receiverEmail.Email);
                    }
                }
                var initSentMail = new SentMail()
                {
                    MailTemplateId = mailTemplate.Id,
                };
                foreach (var receiverEmail in allReceiverEmails)
                {
                    initSentMail.ToEmail = receiverEmail.Email;
                    initSentMail.CompanyId = receiverEmail.CompanyId;
                    sentMails.Add(initSentMail);
                }

                await _sentMailWriteUseCase.CreateSentMails(sentMails);
                await _emailSender.SendEmailAsync(allReceiverEmailsList, mailTemplate.Topic, body);
            }
            catch (ServicesException)
            {

                throw;
            }
            catch (Exception)
            {

                throw new Exception(ErrorMessages.UnexpectedFault);
            }

        }
        public async Task SendEmailByEmail(string email,int mailTemplateId)
        {
            try
            {
                var receiverEmail = await _receiverEmailReadRepository.GetSingle(e => e.Email == email);
                if (receiverEmail == null)
                {
                    throw new ServicesException(ErrorMessages.NotFound);
                }
                var mailTemplate = await _mailTemplateReadRepository.GetSingle(t => t.Id == mailTemplateId);
                if (mailTemplate == null)
                {
                    throw new ServicesException(ErrorMessages.NotFound);
                }
                var body = CreateEmailBody(mailTemplate.Body);
                var initSentMail = new SentMail()
                {
                    MailTemplateId = mailTemplate.Id,
                    CompanyId = receiverEmail.CompanyId,
                    ToEmail = receiverEmail.Email
                };
                await _sentMailWriteUseCase.CreateSentMail(initSentMail);
                await _emailSender.SendSingleEmailAsync(receiverEmail.Email, mailTemplate.Topic, body);
            }
            catch (ServicesException)
            {

                throw;
            }
            catch (Exception)
            {

                throw new Exception(ErrorMessages.UnexpectedFault);
            }


        }
        public string CreateEmailBody(string templateBody)
        {
            try
            {
                string body = HtmlBody.HtmlBodyCreate;
                body = body.Replace("{0}", templateBody);
                var lastBody = Regex.Replace(body, @"([^\r])\n", "$1");
                return lastBody;
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
