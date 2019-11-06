using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Pages.Profile
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public IndexModel(UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public InfoModel Info { get; set; }

        public class InfoModel
        {
            public string Username { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string FullName { get { return $"{FirstName} {LastName}"; } }

            public Gender Gender { get; set; }

            [DataType(DataType.Date)]
            public DateTime DOB { get; set; }

            public Platform FavouritePlatform { get; set; }

            public Category FavouriteCategory { get; set; }

            public int GameCount { get; set; }

            public int FriendCount { get; set; }

            public int FamilyCount { get; set; }
        }


        public async Task<IActionResult> OnGetAsync(string username)
        {
            var user = string.IsNullOrEmpty(username)
                ? await _userManager.GetUserAsync(User)
                : await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return RedirectToPage("/Profile/DoesNotExist");
            }

            Info = new InfoModel
            {
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                DOB = user.DOB,
                FavouritePlatform = _context.Platform.FirstOrDefault(x => x.Id == user.FavouritePlatformId),
                FavouriteCategory = _context.Category.FirstOrDefault(x => x.Id == user.FavouriteCategoryId),
                GameCount = _context.UserGame.Count(),
                FriendCount = _context.Friendship.Count(),
                FamilyCount = _context.Friendship.Where(x => x.IsFamily).Count()
            };

            return Page();
        }
    }
}