namespace KantineAPIv2.Entities.DataRepository
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetAll();
        Group Get(long id);

        long Add(GroupModel entity);
        void Update(Group entityToUpdate, GroupModel updatedEntity);
        void Delete(Group entity);
    }
}
