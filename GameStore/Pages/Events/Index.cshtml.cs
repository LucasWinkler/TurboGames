using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace GameStore.Pages.Events
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

        public IList<Event> Events { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [TempData]
        public bool IsRegistered { get; set; } = false;

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Identity/Account/Login");
            }

            Events = await _context.Events.ToListAsync();

            IsRegistered = await _context.UserEvents.AnyAsync(x => x.UserId == user.Id);

            return Page();
        }

        public async Task<IActionResult> OnPostRegisterAsync(Guid eventId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Identity/Account/Login");
            }

            var userEvent = await _context.UserEvents.FirstOrDefaultAsync(x => x.EventId == eventId);
            if (userEvent != null)
            {
                StatusMessage = $"Error: You have already registered for the '{_context.Events.FirstOrDefault(x => x.Id == userEvent.EventId).Title}' event.";
                return RedirectToPage();
            }

            try
            {
                _context.UserEvents.Add(
                    new UserEvent
                    {
                        EventId = eventId,
                        UserId = user.Id
                    }
                );

                await _context.SaveChangesAsync();

                StatusMessage = $"You have registered for the '{_context.Events.FirstOrDefault(x => x.Id == eventId).Title}' event.";
                return RedirectToPage("Index");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException);
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostUnregisterAsync(Guid eventId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Identity/Account/Login");
            }

            var userEvent = await _context.UserEvents.FirstOrDefaultAsync(x => x.EventId == eventId);
            if (userEvent == null)
            {
                StatusMessage = $"Error: You are not registered for the '{_context.Events.FirstOrDefault(x => x.Id == userEvent.EventId).Title}' event.";
                return RedirectToPage();
            }

            try
            {
                _context.UserEvents.Remove(userEvent);

                await _context.SaveChangesAsync();

                StatusMessage = $"You have unregistered for the '{_context.Events.FirstOrDefault(x => x.Id == eventId).Title}' event.";
                return RedirectToPage("Index");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException);
            }

            return RedirectToPage();
        }
    }
}
