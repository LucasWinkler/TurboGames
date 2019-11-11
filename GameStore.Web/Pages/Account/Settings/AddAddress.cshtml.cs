using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameStore.Data;
using GameStore.Data.Models;

namespace GameStore.Web.Pages.Account.Settings
{
    public class CreateModel : PageModel
    {
        private readonly TurboGamesContext _context;

        public CreateModel(TurboGamesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Address Address { get; set; }

        public IList<string> MyProperty { get; set; }

        //public async Task<IActionResult> OnGetAsync()
        //{

        //    return Page();
        //}

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Address.Add(Address);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}