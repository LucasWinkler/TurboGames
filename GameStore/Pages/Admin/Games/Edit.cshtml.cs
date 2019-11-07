﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Pages.Admin.Games
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EditModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public SelectList Categories { get; set; }
        public SelectList Platforms { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public Guid Id { get; set; }

            [Required]
            public string Title { get; set; }

            [Required]
            public string Developer { get; set; }

            [Required]
            public Guid CategoryId { get; set; }

            [Required]
            public Guid PlatformId { get; set; }

            [Required]
            public double Price { get; set; }

            [Required]
            public string Description { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            if (!user.IsAdmin)
            {
                return RedirectToPage("/Home/Index");
            }

            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (game == null)
            {
                return NotFound();
            }

            Input = new InputModel
            {
                Id = game.Id,
                Title = game.Title,
                Developer = game.Developer,
                Description = game.Description,
                Price = game.Price,
                CategoryId = game.CategoryId,
                PlatformId = game.PlatformId
            };

            SetDropdownLists();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            if (!ModelState.IsValid)
            {
                SetDropdownLists();

                return Page();
            }

            var game = new Game
            {
                Id = Input.Id,
                Title = Input.Title,
                Developer = Input.Developer,
                Description = Input.Description,
                PlatformId = Input.PlatformId,
                CategoryId = Input.CategoryId,
                Price = Input.Price
            };

            _context.Attach(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(game.Id))
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

        private bool GameExists(Guid id)
        {
            return _context.Game.Any(e => e.Id == id);
        }

        private void SetDropdownLists()
        {
            Categories = new SelectList(_context.Category, "Id", "Name");
            Platforms = new SelectList(_context.Platform, "Id", "Name");
        }
    }
}
