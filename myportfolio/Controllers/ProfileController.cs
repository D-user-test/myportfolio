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
        private readonly Profile _profile;   // or EmailService

        public ProfileController(Profile profile)   // <-- injected here
        {
            _profile = profile;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> Contact(string name,string msg,string sub,string email)
        {

            var sent = await _profile.ProcessedEmail(name, msg, sub, email);
            return sent ? Ok("Sent!") : StatusCode(500, "Failed to send email");
        }
    }

}
