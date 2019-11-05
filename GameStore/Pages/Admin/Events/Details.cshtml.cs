using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameStore.Data;
using GameStore.Models;

namespace GameStore.Pages.Admin.Events
{
  public class DetailsModel : PageModel
  {
    private readonly GameStore.Data.ApplicationDbContext _context;

    public DetailsModel(GameStore.Data.ApplicationDbContext context)
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
