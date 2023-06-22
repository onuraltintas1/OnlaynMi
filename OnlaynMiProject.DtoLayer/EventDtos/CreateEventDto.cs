

using OnlaynMiProject.EntityLayer.Concrete;

namespace OnlaynMiProject.DtoLayer.EventDtos;

public class CreateEventDto
{
    public string Content { get; set; }
    public string Title { get; set; }
    public int GroupId { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public string City { get; set; }
    public string District { get; set; }
}