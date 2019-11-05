using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConestogaVirtualGameStore.Data;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Pages.Admin.Events
{
  public class EditModel : PageModel
  {
    private readonly ConestogaVirtualGameStore.Data.ApplicationDbContext _context;

    public EditModel(ConestogaVirtualGameStore.Data.ApplicationDbContext context)
    {
      _context = context;
    }

    [BindProperty]
    public Event Event { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      Event = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);

      if (Event == null)
      {
        return NotFound();
      }
      return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      _context.Attach(Event).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!EventExists(Event.Id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return RedirectToPage("./Index");
    }

    private bool EventExists(Guid id)
    {
      return _context.Events.Any(e => e.Id == id);
    }
  }
}
