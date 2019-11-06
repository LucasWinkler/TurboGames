using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class Game
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [PersonalData]
        public string Title { get; set; }

        [Required]
        [PersonalData]
        public string Developer { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public Guid PlatformId { get; set; }

        [Required]
        public Platform Platform { get; set; }

        public int TotalRating { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [PersonalData]
        public List<Review> Reviews { get; set; }
    }
}
