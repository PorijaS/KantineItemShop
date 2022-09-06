using IdentityServer4.Models;
using IdentityServer4.Validation;
using KantineAPIv2.Context;
using KantineAPIv2.Entities;
using Microsoft.EntityFrameworkCore;

namespace KantineAPIv2.Identity
{
    public class AuthenticationValidator : IResourceOwnerPasswordValidator
    {
        private readonly DatabaseContext _databaseContext;

        public AuthenticationValidator(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            User? user = await _databaseContext.Users.SingleOrDefaultAsync(x => x.Email == context.UserName);

            if (user != null)
            {
                string hashedPassword = context.Password.Sha256();

                if (hashedPassword == user.Password)
                {
                    context.Result = new GrantValidationResult(user.UserId.ToString(), "custom", DateTime.UtcNow);
                }
            }
        }
    }
}
