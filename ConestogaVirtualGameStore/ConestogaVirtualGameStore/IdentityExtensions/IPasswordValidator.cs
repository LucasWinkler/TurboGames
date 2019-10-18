using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ConestogaVirtualGameStore.Extensions
{
    public interface IPasswordValidator<ApplicationUser> where ApplicationUser : class
    {
        Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user, string password);
    }
}
