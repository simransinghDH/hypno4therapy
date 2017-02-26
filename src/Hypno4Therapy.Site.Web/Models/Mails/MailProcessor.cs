using Hypno4Therapy.Site.Web.Models.Forms;
using Hypno4Therapy.Site.Web.Models.Mails;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Hypno4Therapy.Site.Core.Mails
{
    public class MailProcessor : IMailProcessor
    {
        public bool Send(ContactFormModel contactFormModel)
        {
            try
            {
                using (var message = new MailMessage())
                {
                    message.From = new MailAddress(contactFormModel.Email, contactFormModel.Name);
                    message.To.Add(new MailAddress("info@hypno4therapy.be", "info@hypno4therapy.be"));
                    message.IsBodyHtml = false;
                    message.Subject = "Iemand nam contact op via hypno4therapy.be";
                    message.Body = contactFormModel.ToString();

                    var smtpUser = new NetworkCredential
                    {
                        UserName = ConfigurationManager.AppSettings["Mail.Username"],
                        Password = ConfigurationManager.AppSettings["Mail.Password"],
                    };

                    string host = ConfigurationManager.AppSettings["Mail.Host"];

                    using (var smtpClient = new SmtpClient())
                    {
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = smtpUser;
                        smtpClient.Host = host;
                        smtpClient.Port = 26;
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpClient.Send(message);
                    }
                }
            }
            catch (SmtpException smtpException)
            {
                return false;
            }
            catch (Exception exception)
            {
                return false;
            }

            return true;
        }
    }
}
