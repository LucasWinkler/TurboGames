using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Data.Models
{
    public class ShoppingCartGame
    {
        [Required]
        public Guid CartId { get; set; }

        [Required]
        public ShoppingCart Cart { get; set; }

        [Required]
        public Guid GameId { get; set; }

        [Required]
        public Game Game { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
