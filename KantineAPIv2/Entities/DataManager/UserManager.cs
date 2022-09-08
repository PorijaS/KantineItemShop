using System.Collections.Generic;
using System.Linq;
using KantineAPIv2.Entities.DataRepository;
using KantineAPIv2.Context;
using KantineAPIv2.DataModels;
using IdentityServer4.Models;


namespace KantineAPIv2.Entities.DataManager
{
    //DataManager class that handles Request Call Functionality
    public class UserManager : IUserRepository
    {
        //Creating a db context
        public readonly DatabaseContext _dbContext;

        //Adding a class constructor
        public UserManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get Function that fetches all Users and posts them to a list
        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        //Get Function that takes a id and looks in the database for said id in the User table
        public User Get(long id)
        {
            return _dbContext.Users.FirstOrDefault(e => e.UserId == id);
        }

        //Add function that takes a UserModel and adds it to the User table
        public long Add(UserModel user)
        {
            var hashedPassword = user.Password.Sha256();
            var userEntity = new User(user.Email, hashedPassword, user.GroupId);

            _dbContext.Users.Add(userEntity);
            _dbContext.SaveChanges();

            return userEntity.UserId;
        }

        //Update function that takes a User that you want to update and the updated User
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

        //Delete function that deletes a single Order
        public void Delete(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
