using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public enum Classification { Web = 0, InGame = 1, Reality = 2 }
    public class Event
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Details")]
        public string Details { get; set; }

        [Required]
        [Display(Name = "Classification")]
        public Classification Classification { get; set; }
    }
}
