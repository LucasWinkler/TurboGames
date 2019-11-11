using GameStore.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Data.Models
{
    public class UserGame
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Guid GameId { get; set; }

        [Required]
        public Game Game { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
    }
}
