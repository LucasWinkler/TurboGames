using GameStore.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Data.Models
{
    public class UserAddress
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Guid AddressId { get; set; }

        [Required]
        public Address Address { get; set; }
    }
}
