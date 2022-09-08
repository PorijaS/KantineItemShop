using IdentityServer4.Models;
using IdentityServer4.Validation;
using KantineAPIv2.Context;
using KantineAPIv2.Entities;
using Microsoft.EntityFrameworkCore;

namespace KantineAPIv2.Identity
{
    //Class that Authenticated the login sent by the user
    public class AuthenticationValidator : IResourceOwnerPasswordValidator
    {
        //Creating a db context
        private readonly DatabaseContext _databaseContext;

        //Adding a class constructor
        public AuthenticationValidator(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        //This function will check if there is a user who's email is the same as the username that is being sent via input in the login.
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            User? user = await _databaseContext.Users.SingleOrDefaultAsync(x => x.Email == context.UserName);

            //if the user does exist it will hash the password that has been sent and check if it the same password as the one in the database
            if (user != null)
            {
                string hashedPassword = context.Password.Sha256();

                //If the sent password is the same as the one that is stored, it will store the result so that we can use it to send a token. 
                if (hashedPassword == user.Password)
                {
                    context.Result = new GrantValidationResult(user.UserId.ToString(), "custom", DateTime.UtcNow);
                }
            }
        }
    }
}
