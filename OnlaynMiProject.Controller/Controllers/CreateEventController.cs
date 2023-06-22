using OnlaynMiProject.DtoLayer.Dtos.AppUserDtos;
using OnlaynMiProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlaynMiProject.Controller.Controllers;

public class CreateEventController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly UserManager<AppUser> _userManager;

    public CreateEventController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    // GET
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        ViewData["User"] = values;
        AppUserEditDto appUserEditDto = new AppUserEditDto();
        appUserEditDto.Name = values.Name;
        appUserEditDto.Surname = values.Surname;
        return View();
    }
}