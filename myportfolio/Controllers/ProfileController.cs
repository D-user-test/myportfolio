using Microsoft.AspNetCore.Mvc;
using myportfolio.Models;
using myportfolio.Services.ProfileS;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace myportfolio.Controllers
{
    
    public class ProfileController : Controller
    {
       

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> Contact(string name,string msg,string sub,string email)
        {
           
            Profile pf=new Profile();
            bool emailSent=true;
            var servemail = Environment.GetEnvironmentVariable("EMAIL_ID");
            if (!string.IsNullOrEmpty(servemail) && servemail != "NA")
            {
                string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|G:\w])*)(?<=[0-9a-z])@))" +
                                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
                bool isMatch = Regex.IsMatch(servemail, pattern);
                
                if (isMatch)
                {
                    try
                    {
                        
                         
                        emailSent =await pf.ProcessedEmail(name, msg, sub, email, servemail);
                        if (emailSent) {
                            var fromProcess = Environment.GetEnvironmentVariable("EMAIL_ID", EnvironmentVariableTarget.Process);
                            var fromUser = Environment.GetEnvironmentVariable("EMAIL_ID", EnvironmentVariableTarget.User);
                            var fromMachine = Environment.GetEnvironmentVariable("EMAIL_ID", EnvironmentVariableTarget.Machine);
                            return Json(new { fromProcess = fromProcess, fromUser = fromUser, fromMachine = fromMachine, servemail = servemail });
                        }
                          
                    }
                    
                    catch (Exception e)
                    {
                        
                        var fromProcess = Environment.GetEnvironmentVariable("EMAIL_ID", EnvironmentVariableTarget.Process);
                        var fromUser = Environment.GetEnvironmentVariable("EMAIL_ID", EnvironmentVariableTarget.User);
                        var fromMachine = Environment.GetEnvironmentVariable("EMAIL_ID", EnvironmentVariableTarget.Machine);
                        return Json(new { fromProcess = fromProcess , fromUser = fromUser , fromMachine = fromMachine,servemail=servemail });
                    }
                }

            }
           
            return Json(emailSent);
        }
    }

}
