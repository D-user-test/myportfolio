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




        public async Task<bool> ProcessedEmail(string name, string mesg, string sub, string email,string servemail,string pword)
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
           
               
               
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(servemail, pword);
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(servemail);
                mailMessage.To.Add(servemail);
             
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = "New Portfolio Response";
                mailMessage.Body = msg;
                smtpClient.Timeout = 20000;
                await smtpClient.SendMailAsync(mailMessage).ConfigureAwait(false);
                //await smtpClient.SendMailAsync(mailMessage);
               
                mailMessage.Dispose();

                return true;
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Email sending failed: {ex.Message}");
                throw; // or log to a file/service
            }
        }
    }

}
