using GameStore.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Data.Models
{
    public class Review
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string ReviewerId { get; set; }

        [Required]
        public User Reviewer { get; set; }

        [Required]
        public Guid GameId { get; set; }

        [Required]
        public Game Game { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        [Range(0, 5)]
        public int Rating { get; set; }

        [Required]
        public bool IsAccepted { get; set; } = false;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
