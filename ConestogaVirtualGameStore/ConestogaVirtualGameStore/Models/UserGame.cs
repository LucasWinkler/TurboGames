using ConestogaVirtualGameStore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaVirtualGameStore.Models
{
    public class UserGame
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        [ForeignKey("GameId")]
        public Guid GameId { get; set; }

        [Required]
        public Game Game { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
    }
}
