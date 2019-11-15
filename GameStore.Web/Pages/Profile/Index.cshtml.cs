using GameStore.Data;
using GameStore.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Web.Pages.Profile
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly TurboGamesContext _context;

        [TempData]
        public string StatusMessage { get; set; }

        public bool DoesExist { get; set; }

        public IndexModel(UserManager<User> userManager,
            TurboGamesContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public InfoModel Info { get; set; }

        public bool IsFriend { get; set; }

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
                FavouritePlatform = _context.Platforms.FirstOrDefault(x => x.Id == user.FavouritePlatformId),
                FavouriteCategory = _context.Categories.FirstOrDefault(x => x.Id == user.FavouriteCategoryId),
                GameCount = _context.UserGames.Where(x => x.UserId == user.Id).Count(),
                FriendCount = _context.Friendships.Where(x => (x.ReceiverId == user.Id || x.SenderId == user.Id) && !x.IsFamily && x.RequestStatus == FriendStatusCode.Accepted).Count(),
                FamilyCount = _context.Friendships.Where(x => (x.ReceiverId == user.Id || x.SenderId == user.Id) && x.IsFamily && x.RequestStatus == FriendStatusCode.Accepted).Count()
            };

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                IsFriend = false;
                return Page();
            }

            var friendships = _context.Friendships
                .Include(x => x.Receiver)
                .Include(x => x.Sender)
                .Where(x => x.ReceiverId == currentUser.Id || x.SenderId == currentUser.Id);

            IsFriend = await friendships.AnyAsync(x => (x.Sender.UserName == username || x.Receiver.UserName == username) && (x.RequestStatus == FriendStatusCode.Accepted || x.RequestStatus == FriendStatusCode.Pending));

            return Page();
        }

        public async Task<IActionResult> OnPostAddFriendAsync(string username, bool isFamily = false)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var friendships = _context.Friendships
                .Include(x => x.Receiver)
                .Include(x => x.Sender)
                .Where(x => x.ReceiverId == user.Id || x.SenderId == user.Id);

            if (friendships.Any(x => (x.Sender.UserName == username || x.Receiver.UserName == username) && x.RequestStatus == FriendStatusCode.Pending))
            {
                StatusMessage = $"Error: There is already a pending friend request for that user.";

                return RedirectToPage("./Index");
            }
            else if (friendships.Any(x => (x.Sender.UserName == username || x.Receiver.UserName == username) && x.RequestStatus == FriendStatusCode.Accepted))
            {
                StatusMessage = $"Error: You already have this user added as a friend.";

                return RedirectToPage("./Index");
            }

            var receiver = await _userManager.FindByNameAsync(username);

            if (friendships.Any(x => (x.Sender.UserName == username || x.Receiver.UserName == username) && x.RequestStatus == FriendStatusCode.Rejected))
            {
                var friendship = await friendships.FirstOrDefaultAsync(x => (x.Sender.UserName == username || x.Receiver.UserName == username) && x.RequestStatus == FriendStatusCode.Rejected);
                friendship.RequestStatus = FriendStatusCode.Pending;

                try
                {
                    _context.Update(friendship);
                    await _context.SaveChangesAsync();

                    StatusMessage = $"You have sent them a friend request. You must wait for them to accept it.";
                    return RedirectToPage("./Index");
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.InnerException);
                }
            }

            var newFriendship = new Friendship
            {
                SenderId = user.Id,
                ReceiverId = receiver.Id,
                IsFamily = isFamily
            };

            try
            {
                await _context.AddAsync(newFriendship);
                await _context.SaveChangesAsync();

                StatusMessage = $"You have sent them a friend request. You must wait for them to accept it.";
                return RedirectToPage("./Index");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException);
            }

            return Page();
        }
    }
}