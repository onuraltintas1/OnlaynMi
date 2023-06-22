namespace OnlaynMiProject.EntityLayer.Concrete;

public class Group
{
    public int GroupId { get; set; }
    public string Title { get; set; }   
    public string Content { get; set; }
    public string City { get; set; }
    public string District{ get; set; }
    public string ImageUrl { get; set; }
    public string InviteCode { get; set; }
    
    public AppUser User { get; set; }
    public int UserId { get; set; }
    
    public List<UserGroup>? GroupUsers { get; set; }
    public List<Event>?  Events{ get; set; }
    
}