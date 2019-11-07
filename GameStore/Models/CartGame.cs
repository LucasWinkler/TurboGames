using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Models
{
    public class CartGame
    {
        [Required]
        public Guid CartId { get; set; }

        [Required]
        public Cart Cart { get; set; }

        [Required]
        public Guid GameId { get; set; }

        [Required]
        public Game Game { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
