using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlaynMiProject.EntityLayer.Concrete;

namespace OnlaynMiProject.Controller.ViewComponents.Customer
{
    public class _CustomerLayoutSidebarPartial:ViewComponent
    {
        private UserManager<AppUser> _userManager;

        public _CustomerLayoutSidebarPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var username = _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Name = username.Result.Name;
            ViewBag.SurName = username.Result.Surname;
            return View();
        }
    }
}
