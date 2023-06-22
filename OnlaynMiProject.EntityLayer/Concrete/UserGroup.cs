namespace OnlaynMiProject.EntityLayer.Concrete;

public class UserGroup
{
    public int UserId { get; set; }
    public AppUser User { get; set; }

    public int GroupId { get; set; }
    public Group Group { get; set; }
}