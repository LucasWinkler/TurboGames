using GameStore.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Data.Models
{
    public class Wishlist
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public bool AlreadyExists { get; set; } = false;
    }
}
