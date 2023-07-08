namespace OnlaynMiProject.EntityLayer.Concrete;

public class Event
{
    public int EventId { get; set; }
    public string Content { get; set; }
    public string Title { get; set; }
    public TimeOnly Time { get; set; }
    public DateOnly Date { get; set; }
    
    public DateTimeOffset? CreatedTime { get; set; }

    public string City { get; set; }
    public string District { get; set; }
    
    public List<EventAttendance> EventAttendances { get; set; }
    public List<Transfer>  Transfers{ get; set; }
    
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    
    public int GroupId { get; set; }
    public Group Group { get; set; }
}