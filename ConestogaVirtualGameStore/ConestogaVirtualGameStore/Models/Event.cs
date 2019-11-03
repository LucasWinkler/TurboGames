using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ConestogaVirtualGameStore.Models
{
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
        [DataType(DataType.Text)]
        [Display(Name = "Classification")]
        public string Classification { get; set; }
    }
}
