using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConestogaVirtualGameStore.Models
{
    public class Game
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public int TotalRating { get; set; }

        public double? Price { get; set; }

        [Required]
        public string Description { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
