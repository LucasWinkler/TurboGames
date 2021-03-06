﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Data;
using GameStore.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Web.Pages.Account.Settings
{
    [Authorize]
    public class PreferencesModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TurboGamesContext _context;

        public PreferencesModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            TurboGamesContext context)
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

            [Display(Name = "Favourite category")]
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
                return RedirectToPage("/Account/Login");
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

        private void CreateSelectLists(User user)
        {
            Platforms = _context.Platforms.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name,
                Selected = p.Id == user.FavouritePlatformId
            }).ToList();

            Categories = _context.Categories.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name,
                Selected = p.Id == user.FavouriteCategoryId
            }).ToList();
        }
    }
}