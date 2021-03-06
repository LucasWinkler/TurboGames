﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameStore.Data;
using GameStore.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using GameStore.Data.Queries;

namespace GameStore.Web.Pages.Admin.Manage.Games
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly TurboGamesContext _context;
        private readonly UserManager<User> _userManager;

        public DetailsModel(TurboGamesContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            if (id == null)
            {
                return RedirectToPage("/Admin/Games/Index");
            }
         
            Game = await _context.Games
                .Include(g => g.Category)
                .Include(g => g.Platform)
                .FirstOrDefaultAsync(m => m.Id == id);

            Game.Rating = await _context.GetTotalGameRatingAsync(Game);

            if (Game == null)
            {
                return RedirectToPage("/Admin/Games/Index");
            }

            return Page();
        }
    }
}
