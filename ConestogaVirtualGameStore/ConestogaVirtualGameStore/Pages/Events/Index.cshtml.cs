using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConestogaVirtualGameStore.Data;
using ConestogaVirtualGameStore.Models;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace ConestogaVirtualGameStore.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Event> Event { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Events.ToListAsync();
        }

        public async Task<IActionResult> OnPostRegisterEventAsync(Guid id)
        {

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userEventExists = _context.UserEvents.FirstAsync(x => x.EventId == id);
            if (userEventExists == null )
            {
                StatusMessage = $"You have already registered for this event";
                return Page();
            }

            try
            {
                var userEvent = new UserEvent
                {
                    EventId = id,
                    UserId = user.Id
                };

                _context.UserEvents.Add(userEvent);
                await _context.SaveChangesAsync();

                await _userManager.UpdateAsync(user);
                //await _signInManager.RefreshSignInAsync(user);

                StatusMessage = $"You have registered for {Event.FirstOrDefault(x => x.Id == id).Title}";
                return RedirectToPage();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException);
            }

            return Page();
        }
    }
}
