using IdentityServer4.Models;
using IdentityServer4.Services;
using KantineAPIv2.Context;
using KantineAPIv2.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace KantineAPIv2.Identity
{
    public class ProfileService : IProfileService
    {
        private readonly DatabaseContext _dbContext;

        public ProfileService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            string? subjectValue = context.Subject.FindFirst("sub")?.Value;

            if (subjectValue != null)
            {
                long userId = int.Parse(subjectValue);

                User? user = await _dbContext.Users.FirstOrDefaultAsync(e => e.UserId == userId);
                if (user != null)
                {
                    context.IssuedClaims.Add(new Claim("UserId", subjectValue));
                }
            }
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            bool isActive = true;

            string? subjectValue = context.Subject.FindFirst("sub")?.Value;

            if (subjectValue == null)
            {
                isActive = false;
            }

            context.IsActive = isActive;
            return Task.CompletedTask;
        }
    }
}
