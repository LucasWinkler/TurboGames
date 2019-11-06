using GameStore.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class Cart
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public bool IsCheckedOut { get; set; } = false;
    }
}
