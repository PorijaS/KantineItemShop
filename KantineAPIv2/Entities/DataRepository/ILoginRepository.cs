using KantineAPIv2.DataModels;

namespace KantineAPIv2.Entities.DataRepository
{
    public interface ILoginRepository
    {

        User? Login(LoginModel loginModel);
    }
}
