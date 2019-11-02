using System;
using System.ComponentModel.DataAnnotations;

namespace ConestogaVirtualGameStore.Models
{
    public class GameReview
    {
        [Required]
        public Guid GameId { get; set; }

        [Required]
        public Game Game { get; set; }

        [Required]
        public Guid ReviewId { get; set; }

        [Required]
        public Review Review { get; set; }
    }
}
