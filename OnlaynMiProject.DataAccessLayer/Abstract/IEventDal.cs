using OnlaynMiProject.EntityLayer;
using OnlaynMiProject.EntityLayer.Concrete;

namespace OnlaynMiProject.DataAccessLayer.Abstract;

public interface IEventDal : IGenericDal<Event>
{
    Task<List<Event>> GetEventsByGroupId(int groupId);
    public void CreateAttendance(EventAttendance attendance);
    public EventAttendance GetAttendanceForUser(int eventId, int userId);
    public List<AppUser> GetAttendingUsers(int eventId);
    public void AddTransfer(Transfer transfer);
    public List<Transfer> GetTransfer(int eventId);
}