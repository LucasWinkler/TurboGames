using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameStore.Data;
using GameStore.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace GameStore.Web.Pages.Admin.Games
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly TurboGamesContext _context;
        private readonly UserManager<User> _userManager;

        public EditModel(TurboGamesContext context, UserManager<User> userManager)
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

            if (id == null)
            {
                return RedirectToPage("/Admin/Games/Index");
            }

            var game = await _context.Games
                .Include(g => g.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (game == null)
            {
                return RedirectToPage("/Admin/Games/Index");
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
                    return RedirectToPage("/Admin/Games/Index");
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
            return _context.Games.Any(e => e.Id == id);
        }

        private void SetDropdownLists()
        {
            Categories = new SelectList(_context.Categories, "Id", "Name");
            Platforms = new SelectList(_context.Platforms, "Id", "Name");
        }
    }
}
