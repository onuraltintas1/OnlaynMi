using OnlaynMiProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlaynMiProject.DataAccessLayer.Abstract;
using OnlaynMiProject.DataAccessLayer.Concrete;
using OnlaynMiProject.DataAccessLayer.Repositories;

namespace OnlaynMiProject.DataAccessLayer.EntityFramework;

public class EfGroupDal : GenericRepository<Group>, IGroupDal
{
    public EfGroupDal(Context context) : base(context)
    {
        _context = context;
    }

    private readonly Context _context;
    private readonly UserManager<AppUser> _userManager;

    public List<Group> GetListByUser(int id)
    {
        return _context.Groups.Where(x => x.UserId == id).ToList();
    }

    public List<AppUser> GetGroupMembers(int groupId)
    {
        return _context.Set<UserGroup>()
            .Where(ug => ug.GroupId == groupId)
            .Select(ug => ug.User)
            .ToList();
    }

    public Group GetGroupByİnviteCode(string inviteCode)
    {
        return _context.Groups.FirstOrDefault(x => x.InviteCode == inviteCode);
    }

    public void AddUserToGroup(Group group, AppUser user)
    {
        UserGroup userGroup = new UserGroup
        {
            GroupId = group.GroupId,
            UserId = user.Id
        };
        _context.UserGroups.Add(userGroup);
        _context.SaveChanges();
    }

    public List<Group> GetGroupsForUser(int userId)
    {
        return _context.UserGroups.Where(ug => ug.UserId == userId)
            .Select(ug => ug.Group)
            .ToList();
    }
}
