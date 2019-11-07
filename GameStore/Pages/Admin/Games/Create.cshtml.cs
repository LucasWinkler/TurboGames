﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Pages.Admin.Games
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SelectList Categories { get; set; }
        public SelectList Platforms { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
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

        public CreateModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
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

            try
            {
                await _context.Game.AddAsync(new Game
                {
                    Title = Input.Title,
                    Developer = Input.Developer,
                    Description = Input.Description,
                    PlatformId = Input.PlatformId,
                    CategoryId = Input.CategoryId,
                    Price = Input.Price
                });
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: " + e.InnerException);
            }

            SetDropdownLists();

            return Page();
        }

        private void SetDropdownLists()
        {
            Categories = new SelectList(_context.Category, "Id", "Name");
            Platforms = new SelectList(_context.Platform, "Id", "Name");
        }
    }
}