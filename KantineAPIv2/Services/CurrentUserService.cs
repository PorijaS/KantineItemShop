using KantineAPIv2.Entities.DataRepository;
using System.Security.Claims;

namespace KantineAPIv2.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public long userId
        {
            get
            {
                string? identifier = _contextAccessor.HttpContext?.User?.FindFirstValue("UserId");

                if (!string.IsNullOrEmpty(identifier))
                {
                    return long.Parse(identifier);
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
