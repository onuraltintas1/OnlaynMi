using OnlaynMiProject.DtoLayer.Dtos.AppUserDtos;
using OnlaynMiProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlaynMiProject.BusinessLayer.Abstract;
using OnlaynMiProject.Controller.Models;

namespace OnlaynMiProject.Controller.Controllers
{
    
    public class MyAccountsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IGroupService _groupService;
        private readonly IEventService _eventService;
        private readonly UserManager<AppUser> _userManager;
        public MyAccountsController(UserManager<AppUser> userManager, IGroupService groupService, IEventService eventService)
        {
            _userManager = userManager;
            _groupService = groupService;
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> UserProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var groups = _groupService.GetGroupsForUser(values.Id);
            var events = _eventService.TGetList();
            ViewBag.Name = values.Name + " "+ values.Surname;
            ViewBag.Email = values.Email;
            ViewBag.City = values.City + "/" + values.District;
            var viewModel = new UserProfileModel()
            {
                Groups = groups,
                Events = events
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewData["User"] = values;
            AppUserEditDto appUserEditDto = new AppUserEditDto();
            appUserEditDto.Name = values.Name;
            appUserEditDto.Surname = values.Surname;
            appUserEditDto.PhoneNumber = values.PhoneNumber;
            appUserEditDto.Email = values.Email;
            appUserEditDto.City = values.City;
            appUserEditDto.District = values.District;
            appUserEditDto.ImageUrl = values.ImageUrl;
            return View(appUserEditDto);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDto appUserEditDto)
        {
            if (appUserEditDto.Password == appUserEditDto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.PhoneNumber = appUserEditDto.PhoneNumber;
                user.Surname = appUserEditDto.Surname;
                user.City = appUserEditDto.City;
                user.District = appUserEditDto.District;
                user.Name = appUserEditDto.Name;
                user.ImageUrl = "test";
                user.Email = appUserEditDto.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDto.Password);
                var result=await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Group");
                }
            }
            return View();
        }
    }
}
