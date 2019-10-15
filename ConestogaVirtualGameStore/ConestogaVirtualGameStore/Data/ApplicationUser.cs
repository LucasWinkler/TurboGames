﻿using ConestogaVirtualGameStore.Models;
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
    /// Inherits from IdentityUser so this class is mostly
    /// for additional user properties.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        public Gender Gender { get; set; }

        [PersonalData]
        public DateTime DOB { get; set; }

        [ProtectedPersonalData]
        public Address Address { get; set; }
    }
}
