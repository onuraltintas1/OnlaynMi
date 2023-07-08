using Microsoft.AspNetCore.Mvc;
using OnlaynMiProject.BusinessLayer.Abstract;

namespace OnlaynMiProject.Controller.Controllers;

public class DebtShareController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IEventService _eventService;

    public DebtShareController(IEventService eventService)
    {
        _eventService = eventService;
    }

    public IActionResult Index()
    {
        return View();
        
    }

  
    
}