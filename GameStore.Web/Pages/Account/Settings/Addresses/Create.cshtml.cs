using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameStore.Data;
using GameStore.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using GameStore.Web.Helpers;

namespace GameStore.Web.Pages.Account.Settings.Addresses
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly TurboGamesContext _context;
        private readonly UserManager<User> _userManager;

        [BindProperty]
        public Address Address { get; set; }

        public List<SelectListItem> Countries { get; set; }
        public List<SelectListItem> Provinces { get; set; }

        public CreateModel(TurboGamesContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
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

            Address = new Address();

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

            try
            {
                await _context.Addresses.AddAsync(Address);
                await _context.SaveChangesAsync();

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