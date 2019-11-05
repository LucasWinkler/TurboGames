using GameStore.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Models
{
    public class Review
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string ReviewerId { get; set; }

        [Required]
        public ApplicationUser Reviewer { get; set; }

        [Required]
        public string GameId { get; set; }

        [Required]
        public Game Game { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; } = DateTime.UtcNow;

        // TODO: Pending Review FK
    }
}
