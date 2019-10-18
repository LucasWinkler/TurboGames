using ConestogaVirtualGameStore.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace ConestogaVirtualGameStore.IdentityExtensions
{
    public class UsernameAsPasswordValidator : IPasswordValidator<ApplicationUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user, string password)
        {
            if (string.Equals(user.UserName, password, StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "UsernameAsPassword",
                    Description = "You cannot use your username as your password."
                }));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
