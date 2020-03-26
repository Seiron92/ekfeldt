using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;


namespace project.Helpers
{
    public class MailHelpers
    {
        public static bool Send(string fromAddress, string toAddress, string subject, string content)
        {

            try
            {
            
                var apiKey = Environment.GetEnvironmentVariable("SENGRID_API_KEY");
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(fromAddress, fromAddress);
                var to = new EmailAddress(toAddress, toAddress);
                var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
                var response =  client.SendEmailAsync(msg);

                return true;
            }
            catch
            {
                return false;

            }

        }
    }
}
