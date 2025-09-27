using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.SignalR;

namespace myportfolio.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string JobRole { get; set; }
        public string Experience { get; set; }
        public string Bio { get; set; }
        public string ProfileImageUrl { get; set; }
        public string emailstatus { get; set; }




        public async Task<bool> ProcessedEmail(string name, string mesg, string sub, string email,string servemail)
        {
            try
            {
                var msg = "";

                msg = "<p>Dear Dnyanesh </p>";
                msg = msg + "<p>You have Recieved New Email Response from your Portfolio. </p><br />";
                msg = msg + "<p>The Name of the person: <span class='fw-bold'>" +  name + "</span></p>";
                msg = msg + "<p>Email Id :" + email + "</p>";
                msg = msg + "<p>Email Subject :" + sub + "</p>";

                msg = msg + "<p> Message: " + mesg + "<br /><br />";

                msg = msg + "<p>Best Regards</p>";
           
               
                var emailid = Environment.GetEnvironmentVariable("EMAIL_ID");
                var pword = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(servemail, pword);
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(servemail);
                mailMessage.To.Add(emailid);
             
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = "New Portfolio Response";
                mailMessage.Body = msg;
             
                await smtpClient.SendMailAsync(mailMessage);
               
                mailMessage.Dispose();

                return true;
            }

            catch (Exception ex)
            {
                return false;

            }
        }
    }

}
