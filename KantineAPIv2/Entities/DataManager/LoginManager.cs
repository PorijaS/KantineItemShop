using KantineAPIv2.Context;
using KantineAPIv2.DataModels;
using KantineAPIv2.Entities.DataRepository;

namespace KantineAPIv2.Entities.DataManager
{
    public class LoginManager : ILoginRepository
    {
        public readonly DatabaseContext _dbContext;

        public LoginManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Login function that check user password
        public User? Login(LoginModel loginModel)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == loginModel.Email);

            return user;
        }


    }
}
