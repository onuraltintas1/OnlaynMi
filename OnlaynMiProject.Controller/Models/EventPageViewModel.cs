using OnlaynMiProject.EntityLayer.Concrete;

namespace OnlaynMiProject.Controller.Models;

public class EventPageViewModel
{
    public Event Event { get; set; }
    public List<AppUser> EventAttendances { get; set; }
}