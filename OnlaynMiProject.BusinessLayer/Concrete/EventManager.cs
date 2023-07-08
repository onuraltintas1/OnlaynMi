using OnlaynMiProject.BusinessLayer.Abstract;
using OnlaynMiProject.DataAccessLayer.Abstract;
using OnlaynMiProject.EntityLayer;
using OnlaynMiProject.EntityLayer.Concrete;

namespace OnlaynMiProject.BusinessLayer.Concrete;

public class EventManager : IEventService
{
    private readonly IEventDal _eventDal;

    public EventManager(IEventDal eventDal)
    {
        _eventDal = eventDal;
    }
    public void TInsert(Event t)
    {
        _eventDal.Insert(t);
    }

    public void TDelete(Event t)
    {
        _eventDal.Delete(t);
    }

    public void TUpdate(Event t)
    {
        _eventDal.Update(t);
    }

    public Event TGetByID(int id)
    {
        return _eventDal.GetByID(id);
    }

    public List<Event> TGetList()
    {
        return _eventDal.GetList();
    }

    public async Task<List<Event>> GetEventsByGroupId(int groupId)
    {
        return await _eventDal.GetEventsByGroupId(groupId);
    }

    public void CreateAttendance(EventAttendance attendance)
    {
        _eventDal.CreateAttendance(attendance);
    }

    public EventAttendance GetAttendanceForUser(int eventId, int userId)
    {
        return _eventDal.GetAttendanceForUser(eventId, userId);
    }

    public List<AppUser> GetAttendingUsers(int eventId)
    {
        return _eventDal.GetAttendingUsers(eventId);
    }

    public void AddTransfer(Transfer transfer)
    {
        _eventDal.AddTransfer(transfer);
    }

    public List<Transfer> GetTransfer(int eventId)
    {
       return _eventDal.GetTransfer(eventId);
    }
}