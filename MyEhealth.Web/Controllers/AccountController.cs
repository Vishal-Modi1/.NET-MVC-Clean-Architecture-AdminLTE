using Microsoft.AspNetCore.Mvc;
using MyEhealth.Web.Models.ViewModels;

namespace MyEhealth.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult LoginPost(LoginInputModel loginInputModel)
        {
            if (loginInputModel is not null 
                && !string.IsNullOrEmpty(loginInputModel.Email) 
                && !string.IsNullOrEmpty(loginInputModel.Password))
            {
                return RedirectToAction("Index","Home");
            }

            return View("Login", loginInputModel);
        }

        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult RegisterPost(RegisterInputModel registerInputModel)
        {
            if (registerInputModel is not null
                && !string.IsNullOrEmpty(registerInputModel.Email)
                && !string.IsNullOrEmpty(registerInputModel.Password))
            {
                return RedirectToAction("Index", "Home");
            }

            return View("Register", registerInputModel);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPasswordPost(string email, string password)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Index");
            }

            return View("ForgotPassword");
        }
    }
}
