using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Data;
using GameStore.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Web.Pages.Friends
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly TurboGamesContext _context;

        public IList<Friendship> Friendships { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public IndexModel(UserManager<User> userManager, TurboGamesContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            Friendships = await _context.Friendship
                .Include(f => f.Receiver)
                .Include(f => f.Sender)
                .Where(x => x.ReceiverId == user.Id || x.SenderId == user.Id).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAcceptAsync(string id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            Friendships = await _context.Friendship
                .Include(f => f.Receiver)
                .Include(f => f.Sender)
                .Where(x => x.ReceiverId == user.Id || x.SenderId == user.Id).ToListAsync();

            var friendship = Friendships.FirstOrDefault(x => x.ReceiverId == id || x.SenderId == id);

            friendship.RequestStatus = FriendStatusCode.Accepted;

            try
            {
                _context.Friendship.Update(friendship);
                await _context.SaveChangesAsync();

                StatusMessage = $"You have accepted their friend request.";
                return RedirectToPage("Index");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException);
            }

            StatusMessage = $"Error: Couldn't accept friend.";
            return Page();
        }

        public async Task<IActionResult> OnPostRejectAsync(string id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            Friendships = await _context.Friendship
                .Include(f => f.Receiver)
                .Include(f => f.Sender)
                .Where(x => x.ReceiverId == user.Id || x.SenderId == user.Id).ToListAsync();

            var friendship = Friendships.FirstOrDefault(x => x.ReceiverId == id || x.SenderId == id);

            friendship.RequestStatus = FriendStatusCode.Rejected;

            try
            {
                _context.Friendship.Update(friendship);
                await _context.SaveChangesAsync();

                StatusMessage = $"You have rejected their friend request.";
                return RedirectToPage("Index");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException);
            }

            StatusMessage = $"Error: Couldn't reject friend.";
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            Friendships = await _context.Friendship
                .Include(f => f.Receiver)
                .Include(f => f.Sender)
                .Where(x => x.ReceiverId == user.Id || x.SenderId == user.Id).ToListAsync();

            var friendship = Friendships.FirstOrDefault(x => x.ReceiverId == id || x.SenderId == id);

            try
            {
                _context.Friendship.Remove(friendship);
                await _context.SaveChangesAsync();

                StatusMessage = $"You have deleted them as a friend.";
                return RedirectToPage("Index");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException);
            }

            StatusMessage = $"Error: Couldn't delete friend.";
            return Page();
        }
    }
}