using KantineAPIv2.DataModels;

namespace KantineAPIv2.Entities.DataRepository
{
    //Repository Interface where all the Requests Call functions are created, they are created here but they dont have their functionality added yet.
    public interface IGroupRepository
    {
        IEnumerable<Group> GetAll();
        Group Get(long id);

        long Add(GroupModel entity);
        void Update(Group entityToUpdate, GroupModel updatedEntity);
        void Delete(Group entity);
    }
}
