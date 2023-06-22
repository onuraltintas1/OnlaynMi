using OnlaynMiProject.EntityLayer.Concrete;

namespace OnlaynMiProject.DataAccessLayer.Abstract;

public interface IGroupDal: IGenericDal<Group>
{
    public List<Group> GetListByUser(int id);
    public List<AppUser> GetGroupMembers(int groupId);
    public Group GetGroupByİnviteCode(string inviteCode);
    public void  AddUserToGroup(Group group, AppUser user);

    public List<Group> GetGroupsForUser(int userId);

}