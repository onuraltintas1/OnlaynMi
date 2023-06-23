using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlaynMiProject.BusinessLayer.Abstract;
using OnlaynMiProject.BusinessLayer.Concrete;
using OnlaynMiProject.Controller.Models;
using OnlaynMiProject.DtoLayer.EventDtos;
using OnlaynMiProject.EntityLayer.Concrete;

namespace OnlaynMiProject.Controller.Controllers;
[Authorize]
public class EventController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IGroupService _groupManager;
    private readonly IEventService _eventService;
    public EventController(UserManager<AppUser> userManager, IGroupService groupManager, IEventService eventService)
    {
        _userManager = userManager;
        _groupManager = groupManager;
        _eventService = eventService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var groups=_groupManager.GetGroupsForUser(user.Id);
        ViewData["Groups"] = new SelectList(groups, "GroupId", "Title");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEventDto createEventDto)
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var id = user.Id;
        var groups=_groupManager.GetGroupsForUser(user.Id);
        ViewData["Groups"] = new SelectList(groups, "GroupId", "Title");
        

        Event eventt = new Event();
        eventt.Title = createEventDto.Title;
        eventt.Content = createEventDto.Content;
        eventt.Date = DateOnly.FromDateTime(createEventDto.Date);
        eventt.Time = TimeOnly.FromTimeSpan(createEventDto.Time);
        eventt.GroupId= createEventDto.GroupId;
        eventt.City = createEventDto.City;
        eventt.District = createEventDto.District;
        eventt.AppUserId = id;
      
        _eventService.TInsert(eventt);
        return RedirectToAction("Index", "Group");
    
    }
    
    [HttpGet("event/EventPage/{eventId}")]
    public async Task<IActionResult> EventPage(int eventId)
    {
        var eventAttendances = new EventAttendance();
        var value = _eventService.TGetByID(eventId);
        var user = await _userManager.FindByIdAsync(value.AppUserId.ToString());
        ViewData["AppUserName"] = user.Name +" "+ user.Surname;
        var online = _eventService.GetAttendingUsers(eventId);

        var viewModel = new EventPageViewModel()
        {
            Event = value,
            EventAttendances = online,

        };
        return View(viewModel);
    }

    [HttpPost("event/EventPage/{eventId}")]
    public async Task<IActionResult> EventPage(int eventId,bool attendance)
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var newAttendance = new EventAttendance
        {
            EventId = eventId,
            AppUserId = user.Id,
            IsAttending = attendance
        };
        _eventService.CreateAttendance(newAttendance);
        return RedirectToAction("EventPage",new {eventId});
    }
}