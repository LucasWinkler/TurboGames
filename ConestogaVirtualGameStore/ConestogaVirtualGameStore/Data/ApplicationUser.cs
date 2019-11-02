using ConestogaVirtualGameStore.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace ConestogaVirtualGameStore.Data
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
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime DOB { get; set; }

        public Guid? AddressId { get; set; }

        public Address Address { get; set; }

        public Guid? PaymentId { get; set; }

        public Payment Payment { get; set; }
    }
}
