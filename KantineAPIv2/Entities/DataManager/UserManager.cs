using System.Collections.Generic;
using System.Linq;
using KantineAPIv2.Entities.DataRepository;
using KantineAPIv2.Context;
using KantineAPIv2.DataModels;
using IdentityServer4.Models;


namespace KantineAPIv2.Entities.DataManager
{
    public class UserManager
    {
        public class UserManager : IUserRepository
        {
            public readonly DatabaseContext _dbContext;

            public UserManager(DatabaseContext dbContext)
            {
                _dbContext = dbContext;
            }

            public IEnumerable<User> GetAll()
            {
                return _dbContext.Users.ToList();
            }

            public User Get(long id)
            {
                return _dbContext.Users.FirstOrDefault(e => e.UserId == id);
            }

            public long Add(UserModel user)
            {
                var hashedPassword = user.Password.Sha256();
                var userEntity = new User(user.Email, hashedPassword, user.GroupId);

                _dbContext.Users.Add(userEntity);
                _dbContext.SaveChanges();

                return userEntity.UserId;
            }

            public void Update(User userToUpdate, UpdateUserModel updatedUser)
            {
                if (updatedUser.OldPassword.Sha256() == userToUpdate.Password)
                {
                    var hashedPassword = updatedUser.Password.Sha256();

                    userToUpdate.Email = updatedUser.Email;
                    userToUpdate.Password = hashedPassword;
                    userToUpdate.GroupId = updatedUser.GroupId;
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new UnauthorizedAccessException();
                }
            }

            public void Delete(User user)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }
    }
}
