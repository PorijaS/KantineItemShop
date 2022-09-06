namespace KantineAPIv2.Entities.DataRepository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(long id);

        long Add(UserModel entity);
        void Update(User entityToUpdate, UpdateUserModel updatedEntity);
        void Delete(User entity);
    }
}
