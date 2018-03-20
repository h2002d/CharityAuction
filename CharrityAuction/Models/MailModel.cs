using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;

namespace CharrityAuction.Models
{
    public class MailModel
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }


        public void SendMail()
        {
            try
            {
                
                string EmailFrom = WebConfigurationManager.AppSettings["EmailFrom"];
                string EmailFromPassword = WebConfigurationManager.AppSettings["EmailFromPassword"];

                MailMessage mail = new MailMessage();
                mail.To.Add(Email);
                mail.From = new MailAddress(EmailFrom);
                mail.Subject = Subject;

                mail.Body = Body.ToString();
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(EmailFrom, EmailFromPassword); // Enter seders User name and password   
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }
    }
}