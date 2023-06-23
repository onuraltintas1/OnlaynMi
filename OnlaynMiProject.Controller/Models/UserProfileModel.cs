using OnlaynMiProject.EntityLayer.Concrete;

namespace OnlaynMiProject.Controller.Models;

public class UserProfileModel
{
    public List<Group> Groups { get; set; }
    public List<Event>  Events { get; set; }

}