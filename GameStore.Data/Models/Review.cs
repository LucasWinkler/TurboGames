using GameStore.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Data.Models
{
    public enum ReviewStatus { Pending = 0, Accepted = 1 }

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
        [MaxLength(8000)]
        public string Content { get; set; }

        [Required]
        [Range(1, 5)]
        public double Rating { get; set; } = 1d;

        [Required]
        public ReviewStatus ReviewStatus { get; set; } = ReviewStatus.Pending;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
