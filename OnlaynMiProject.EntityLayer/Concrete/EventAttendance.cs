namespace OnlaynMiProject.EntityLayer.Concrete;

public class EventAttendance
{
    public int EventAttendanceId { get; set; }
    public bool IsAttending { get; set; }
    
    public int EventId { get; set; }
    public Event Event { get; set; }

    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}