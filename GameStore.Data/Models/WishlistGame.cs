using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GameStore.Data.Models
{
    public class WishlistGame
    {
        [Required]
        public Guid WishlistId { get; set; }

        [Required]
        public Wishlist wishlist { get; set; }

        [Required]
        public Guid GameId { get; set; }

        [Required]
        public Game Game { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
