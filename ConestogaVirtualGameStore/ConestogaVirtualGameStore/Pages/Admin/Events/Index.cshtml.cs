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
  public class IndexModel : PageModel
  {
    private readonly ConestogaVirtualGameStore.Data.ApplicationDbContext _context;

    public IndexModel(ConestogaVirtualGameStore.Data.ApplicationDbContext context)
    {
      _context = context;
    }

    public IList<Event> Event { get; set; }

    public async Task OnGetAsync()
    {
      Event = await _context.Events.ToListAsync();
    }
  }
}
