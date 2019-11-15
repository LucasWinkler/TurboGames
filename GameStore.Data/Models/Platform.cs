using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Data.Models
{
    public class Platform
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
