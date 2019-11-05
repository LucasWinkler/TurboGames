using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameStore.Data;
using GameStore.Models;

namespace GameStore.Pages.Admin.Events
{
  public class CreateModel : PageModel
  {
    private readonly GameStore.Data.ApplicationDbContext _context;

    public CreateModel(GameStore.Data.ApplicationDbContext context)
    {
      _context = context;
    }

    public IActionResult OnGet()
    {
      return Page();
    }

    [BindProperty]
    public Event Event { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      _context.Events.Add(Event);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}