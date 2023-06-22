using Microsoft.AspNetCore.Authorization;
using OnlaynMiProject.BusinessLayer.Abstract;
using OnlaynMiProject.BusinessLayer.Concrete;
using OnlaynMiProject.DtoLayer.Dtos.GroupDtos;
using OnlaynMiProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OnlaynMiProject.Controller.Controllers;

public class GroupController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IGroupService _groupManager;
    private readonly IEventService _eventService;
    public GroupController(UserManager<AppUser> userManager, IGroupService groupManager, IEventService eventService)
    {
        _userManager = userManager;
        _groupManager = groupManager;
        _eventService = eventService;
    }
    // GET
    public async Task<ActionResult> Index()
    {
       var user = await _userManager.FindByNameAsync(User.Identity.Name);
       var i = user.Id;
       return View(_groupManager.GetGroupsForUser(i));
    }
    
    [HttpGet]
    public IActionResult CreateGroup()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateGroup(CreateGroupDto createGroupDto)
    {
        var user =  _userManager.FindByNameAsync(User.Identity.Name).Id;
        Random rnd = new Random();
        string code;
        code = rnd.Next(10000, 100000).ToString();
        ViewData["User"] = code;
        Group group = new Group();
        group.Title = createGroupDto.Title;
        group.Content = createGroupDto.Content;
        group.City = createGroupDto.City;
        group.District = createGroupDto.District;
        group.InviteCode = code;
        group.UserId = user;
        group.ImageUrl = "adsasddas";
        _groupManager.TInsert(group);
      
            return RedirectToAction("Index", "Group");
        
        return View();
    }

    [HttpGet("group/Members/{groupId}")]
    public async Task<IActionResult> Members(int groupId)
    {
        List<AppUser> members =  _groupManager.GetGroupMembers1(groupId);
        return View(members);
    }

    [HttpGet]
    public async Task<IActionResult> JoingGroup()
    {
        return View();
    }
    

    [HttpPost]
    public async Task<IActionResult> JoingGroup(JoinUserDto model)
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        Group group = _groupManager.GetByInviteCode(model.InviteCode);
        if (group.InviteCode == model.InviteCode)
        {
            model.GroupName = group.Title;
            _groupManager.AddUserToGroup(group,user);
            return RedirectToAction("Index", "Group");
        }
        else
        {
            ModelState.AddModelError(string.Empty,"Geçersiz Davet kodu.");
        }
        
        return View();
    }
    
    
    [HttpGet("group/GroupPage/{groupId}")]
    public async Task<IActionResult> GroupPage(int groupId)
    {
        var events = await _eventService.GetEventsByGroupId(groupId);
        return View(events);
    }


    

}