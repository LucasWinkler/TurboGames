using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameStore.Data;
using GameStore.Data.Models;
using Microsoft.AspNetCore.Identity;
using GameStore.Web.Helpers;

namespace GameStore.Web.Pages.Account.Settings.Addresses
{
    public class EditModel : PageModel
    {
        private readonly TurboGamesContext _context;
        private readonly UserManager<User> _userManager;

        [BindProperty]
        public Address Address { get; set; }

        public List<SelectListItem> Countries { get; set; }
        public List<SelectListItem> Provinces { get; set; }

        public EditModel(TurboGamesContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(Guid addressId)
        {
            if (addressId == null)
            {
                return RedirectToPage("./Index");
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            Address = await _context.Addresses.FirstOrDefaultAsync(m => m.Id == addressId);

            if (Address == null)
            {
                return RedirectToPage("./Index");
            }

            Countries = new List<SelectListItem>();
            Countries.AddRange(AddressHelper.GetCountries().Select(keyValue => new SelectListItem()
            {
                Value = keyValue.Key,
                Text = keyValue.Value
            }).OrderBy(x => x.Text));

            Provinces = new List<SelectListItem>();
            Provinces.AddRange(AddressHelper.GetProvinces().Select(keyValue => new SelectListItem()
            {
                Value = keyValue.Key,
                Text = keyValue.Value

            }).OrderBy(x => x.Text));

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            _context.Attach(Address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(Address.Id))
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AddressExists(Guid id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }
    }
}
