using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int TotalRating { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public Category Category { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
