using OnlaynMiProject.EntityLayer.Concrete;

namespace OnlaynMiProject.BusinessLayer.Abstract;

public interface IGroupService: IGenericService<Group>
{
    public List<Group> GetGroups(int id);
    public List<AppUser> GetGroupMembers1(int groupId);
    public Group GetByInviteCode(string inviteCode);
    public void AddUserToGroup(Group group, AppUser user);
    public List<Group> GetGroupsForUser(int userId);

}