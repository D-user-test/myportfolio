using Microsoft.AspNetCore.Mvc;
using myportfolio.Models;
using myportfolio.Services.ProfileS;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace myportfolio.Controllers
{
    
    public class ProfileController : Controller
    {
        //private readonly IProfileRepository _repo;

        //public ProfileController(IProfileRepository repo)
        //{
        //    _repo = repo;
        //}


        //[HttpGet]
        //public IActionResult profile()
        //{
        //    try
        //    {
        //        HttpContext.Session.SetString("username", "user");
        //        var val = _repo.GetAll();

        //        return View(val);
        //    }
        //    catch (Exception ex)
        //    {
              
        //        return View(ex);
        //    }
          
        //}

        //[HttpGet]
        //public IActionResult Create() {

        //    try
        //    {
        //        return View();
        //    }
        //    catch (Exception ex)
        //    {
        //        return View(ex);
        //    }

        //} 

        //[HttpPost]
        //public IActionResult Create(Profile profile)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _repo.Create(profile);
        //            return RedirectToAction("Index");
        //        }
        //        return View(profile); ;
        //    }
        //    catch (Exception ex)
        //    {

        //        return View(ex);
        //    }
            
        //}

        //[HttpGet]
        //public IActionResult Edit(int id) {
        //    try
        //    {
        //        return View(_repo.GetById(id));
        //    }
        //    catch (Exception ex)
        //    {
        //        return View(ex);
        //    }
           
        //}

        //[HttpPost]
        //public IActionResult Edit(Profile profile)
        //{
        //    try
        //    {
        //        _repo.Update(profile);
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        return View(ex);
        //    }
            
        //}

        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    try
        //    {
        //        _repo.Delete(id);
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        return View(ex);
        //    }
           
        //}
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
                        
                            return Json(true);
                        }
                          
                    }
                    
                    catch (Exception e)
                    {
                        return Json(false);
                    }
                }

            }
           
            return Json(emailSent);
        }
    }

}
