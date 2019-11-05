using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ConestogaVirtualGameStore.Data;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Pages.Admin.Events
{
  public class CreateModel : PageModel
  {
    private readonly ConestogaVirtualGameStore.Data.ApplicationDbContext _context;

    public CreateModel(ConestogaVirtualGameStore.Data.ApplicationDbContext context)
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