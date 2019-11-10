using GameStore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Data
{
    /// <summary>
    /// The genders that a user may choose from.
    /// </summary>
    public enum Gender { Female = 0, Male = 1, Other = 2 }

    /// <summary>
    /// A registered/authorized user in the application.
    /// Inherits from IdentityUser so this class is for
    /// adding additional user properties that don't
    /// exist within IdentityUser.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        public Guid? BillingAddressId { get; set; }

        public Address BillingAddress { get; set; } 
        
        public Guid? ShippingAddressId { get; set; }

        public Address ShippingAddress { get; set; }

        public Guid? PaymentId { get; set; }

        public Payment Payment { get; set; }

        [Required]
        public bool IsAdmin { get; set; } = false;

        public Guid? FavouritePlatformId { get; set; }

        public Platform FavouritePlatform { get; set; }

        public Guid? FavouriteCategoryId { get; set; }

        public Category FavouriteCategory { get; set; }

        [Required]
        public bool ShouldReceiveEmails { get; set; } = false;
    }
}
