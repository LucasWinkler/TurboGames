using ConestogaVirtualGameStore.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace ConestogaVirtualGameStore.Models
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
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        // TODO: Pending Review FK
    }
}
