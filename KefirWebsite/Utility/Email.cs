using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace System
{
    public class Email
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public string ErrorDescription { get; set; }
        public Email()
        {
            HostName = "smtp.mail.yahoo.com";
            Port = 587;
            EmailAddress = "delnoosh2016@yahoo.com";
            #region Property
            Password = "+A0123456789";
            #endregion
        }


        public bool Send(string Body, string Subject, List<string> ListEmail)
        {

            MailMessage mail = new MailMessage();
            mail.BodyEncoding = System.Text.UTF8Encoding.UTF8;
            mail.Subject = Subject;
            mail.IsBodyHtml = true;
            mail.From = new MailAddress(EmailAddress, "کفیر");
            mail.Body = "<div>" + Body + "  </div>";
            foreach (var item in ListEmail)
            {
                mail.To.Add(new MailAddress(item));
            }



            SmtpClient smtp = new SmtpClient(HostName, 587);
            smtp.Credentials = new NetworkCredential(EmailAddress, Password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return true;


        }
    }
}