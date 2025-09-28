using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.SignalR;
using System.Text;
using SendGrid;
using SendGrid.Helpers.Mail;

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

        private readonly IConfiguration _config;

        public Profile(IConfiguration config)   // <-- requires config
        {
            _config = config;
        }



        public async Task<bool> ProcessedEmail(string name, string mesg, string sub, string email,string fromEmail,string toEmail,string apiKey)
        {
            try
            {
               
                
                var sb = new StringBuilder();
                sb.Append("<p>Dear,</p>");
                sb.Append("<p>You have received a new response from your Portfolio.</p><br />");
                sb.Append($"<p>The Name of the person: <strong>{name}</strong></p>");
                sb.Append($"<p>Email Id: {email}</p>");
                sb.Append($"<p>Email Subject: {sub}</p>");
                sb.Append($"<p>Message: {mesg}</p><br /><br />");
                sb.Append("<p>Best Regards</p>");

                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(fromEmail, "Portfolio");
                var to = new EmailAddress(toEmail, "Admin");
                var subject = "New Portfolio Response";

                var msg = MailHelper.CreateSingleEmail(from, to, subject, sb.ToString(), sb.ToString());
                var response = await client.SendEmailAsync(msg);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SendGrid email failed: {ex.Message}");
                return false;
            }
        }
    }
}
