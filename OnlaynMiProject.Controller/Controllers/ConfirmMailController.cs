using OnlaynMiProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlaynMiProject.Controller.Models;

namespace OnlaynMiProject.Controller.Controllers
{
    public class ConfirmMailController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var value = TempData["Mail"];
            ViewBag.v = value;
          //  confirmMailViewModel.Mail = value.ToString();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel)
        {
            var user = await _userManager.FindByEmailAsync(confirmMailViewModel.Mail);
            if (user.ConfirmCode == confirmMailViewModel.ConfirmCode)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
//Kullanıcı Adı - şifre eşleşmeli <-> email confirmed olmalı