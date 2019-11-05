using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConestogaVirtualGameStore.Data;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Pages.Admin.Events
{
  public class DetailsModel : PageModel
  {
    private readonly ConestogaVirtualGameStore.Data.ApplicationDbContext _context;

    public DetailsModel(ConestogaVirtualGameStore.Data.ApplicationDbContext context)
    {
      _context = context;
    }

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
  }
}
