using GameStore.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Data.Models
{
    public class ShoppingCart
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public bool IsCheckedOut { get; set; } = false;
    }
}
