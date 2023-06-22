using OnlaynMiProject.DataAccessLayer.Abstract;
using OnlaynMiProject.EntityLayer.Concrete;
using OnlaynMiProject.BusinessLayer.Abstract;

namespace OnlaynMiProject.BusinessLayer.Concrete;

public class GroupManager : IGroupService
{
    private readonly IGroupDal _groupDal;
   

    public GroupManager(IGroupDal groupDal)
    {
        _groupDal = groupDal;
    }

    public void TInsert(Group t)
    {
        _groupDal.Insert(t);
    }

    public void TDelete(Group t)
    {
        _groupDal.Delete(t);
    }

    public void TUpdate(Group t)
    {
        _groupDal.Update(t);
    }

    public Group TGetByID(int id)
    {
        return _groupDal.GetByID(id);
    }

    public List<Group> TGetList()
    {
        return _groupDal.GetList();
    }

    public List<Group> GetGroups(int id)
    {
        return _groupDal.GetListByUser(id);
    }

    public List<AppUser> GetGroupMembers1(int groupId)
    {
        return _groupDal.GetGroupMembers(groupId);
    }

    public Group GetByInviteCode(string inviteCode)
    {
        return _groupDal.GetGroupByİnviteCode(inviteCode);
    }
    public void AddUserToGroup(Group group, AppUser user)
    {
        _groupDal.AddUserToGroup(group, user);
    }

    public List<Group> GetGroupsForUser(int userId)
    {
        return _groupDal.GetGroupsForUser(userId);
    }
}