using KantineAPIv2.DataModels;

namespace KantineAPIv2.Entities.DataRepository
{
    //Repository Interface where all the Requests Call functions are created, they are created here but they dont have their functionality added yet.
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(long id);

        long Add(UserModel entity);
        void Update(User entityToUpdate, UpdateUserModel updatedEntity);
        void Delete(User entity);
    }
}
