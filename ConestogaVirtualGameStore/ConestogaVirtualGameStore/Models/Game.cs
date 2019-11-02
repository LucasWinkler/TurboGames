using System;
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
        public Guid GameReviewId { get; set; }

        [Required]
        public GameReview GameReview { get; set; }

        public int TotalRating { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public Category Category { get; set; }
    }
}
