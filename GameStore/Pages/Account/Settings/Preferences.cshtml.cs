using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Pages.Account.Settings
{
    public class PreferencesModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public PreferencesModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Favourite platform")]
            public Guid? PlatformId { get; set; }

            [Display(Name = "Favourite cateogry")]
            public Guid? CategoryId { get; set; }

        }

        public List<SelectListItem> Platforms { get; set; }
        public List<SelectListItem> Categories { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            CreateSelectLists(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                CreateSelectLists(user);
                return Page();
            }

            var selectedPlatform = Input.PlatformId;
            if (selectedPlatform != user.FavouritePlatformId)
            {
                user.FavouritePlatformId = selectedPlatform;
            }

            var selectedCategory = Input.CategoryId;
            if (selectedCategory != user.FavouriteCategoryId)
            {
                user.FavouriteCategoryId = selectedCategory;
            }

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await _signInManager.RefreshSignInAsync(user);

                StatusMessage = "Your preferences has been updated";
                return RedirectToPage();
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            CreateSelectLists(user);
            return Page();
        }

        private void CreateSelectLists(ApplicationUser user)
        {
            Platforms = _context.Platform.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name,
                Selected = p.Id == user.FavouritePlatformId
            }).ToList();

            Categories = _context.Category.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name,
                Selected = p.Id == user.FavouriteCategoryId
            }).ToList();
        }
    }
}