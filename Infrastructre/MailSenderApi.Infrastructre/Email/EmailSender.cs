using MailSenderApi.Application.Interfaces;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace MailSenderApi.Infrastructre.Email
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(List<string> toEmail, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(Configuration.GetEmailHost, Configuration.GetEmailPassword));
            foreach (var emails in toEmail)
            {
                email.To.Add(new MailboxAddress("", emails));
            }            
            email.Subject = subject;
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = body
            };
            email.Body = bodyBuilder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                await smtp.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(Configuration.GetEmailHost, Configuration.GetEmailPassword);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
        }
        public async Task SendSingleEmailAsync(string toEmail, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(Configuration.GetEmailHost, Configuration.GetEmailPassword));
            email.To.Add(new MailboxAddress("", toEmail));
            email.Subject = subject;
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = body
            };
            email.Body = bodyBuilder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                await smtp.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(Configuration.GetEmailHost, Configuration.GetEmailPassword);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
        }
    }
}
