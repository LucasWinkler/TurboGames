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
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public bool DoesExist { get; set; }

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
                DoesExist = false;
                return Page();
            }

            DoesExist = true;

            Info = new InfoModel
            {
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                DOB = user.DOB,
                FavouritePlatform = _context.Platform.FirstOrDefault(x => x.Id == user.FavouritePlatformId),
                FavouriteCategory = _context.Category.FirstOrDefault(x => x.Id == user.FavouriteCategoryId),
                GameCount = _context.UserGame.Where(x => x.UserId == user.Id).Count(),
                FriendCount = _context.Friendship.Where(x => x.ReceiverId == user.Id || x.SenderId == user.Id).Count(),
                FamilyCount = _context.Friendship.Where(x => (x.ReceiverId == user.Id || x.SenderId == user.Id) && x.IsFamily).Count()
            };

            return Page();
        }
    }
}