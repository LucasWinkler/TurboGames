using GameStore.Data.Models;
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
    public class User : IdentityUser
    {
        [Required]
        public bool IsAdmin { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public bool ShouldReceiveEmails { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of birth")]
        public DateTime DOB { get; set; }

        // Credit card information
        public Guid? PaymentId { get; set; }
        public Payment Payment { get; set; }

        // Favourite platform
        public Guid? FavouritePlatformId { get; set; }
        public Platform FavouritePlatform { get; set; }

        // Favourite category
        public Guid? FavouriteCategoryId { get; set; }
        public Category FavouriteCategory { get; set; }
    }
}
