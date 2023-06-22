using Microsoft.EntityFrameworkCore;
using OnlaynMiProject.DataAccessLayer.Abstract;
using OnlaynMiProject.DataAccessLayer.Concrete;
using OnlaynMiProject.DataAccessLayer.Repositories;
using OnlaynMiProject.EntityLayer.Concrete;

namespace OnlaynMiProject.DataAccessLayer.EntityFramework;

public class EfEventDal: GenericRepository<Event>, IEventDal
{
    public EfEventDal(Context context) : base(context)
    {
        _context = context;
    }
    private readonly Context _context;
    
    public async Task<List<Event>> GetEventsByGroupId(int groupId)
    {
        return await _context.Event.Where(e => e.GroupId == groupId).ToListAsync();
    }
    
    public void CreateAttendance(EventAttendance attendance)
    {
        _context.EventAttendances.Add(attendance);
        _context.SaveChanges();
    } 
    public EventAttendance GetAttendanceForUser(int eventId, int userId)
    {
        // EventAttendance tablosundan kullanıcının katılım durumunu alın
        var attendance = _context.EventAttendances.FirstOrDefault(a => a.EventId == eventId && a.AppUserId == userId);
    
        return attendance;
    }

    public List<AppUser> GetAttendingUsers(int eventId)
    {
        return _context.EventAttendances
            .Where(ea => ea.EventId == eventId && ea.IsAttending)
            .Select(ea => ea.AppUser)
            .ToList();
    }
}