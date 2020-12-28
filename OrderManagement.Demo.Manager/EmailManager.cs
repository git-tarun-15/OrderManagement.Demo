using Newtonsoft.Json;
using OrderManagement.Demo.Interfaces;
using OrderManagement.Demo.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Demo.Manager
{
    public class EmailManager : IEmailManager
    {
        public EmailManager()
        {          
        }

        public async Task<bool> SendEmail(string to, string from, string body, string subject)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(from);
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = body;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("FromMailAddress", "password");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                await smtp.SendMailAsync(message);
                
            }
            catch (Exception)
            {
                
            }
            // Testing purpose we are sending true
            return true;
        }
    }
}
