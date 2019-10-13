using Microsoft.AspNetCore.Identity;
using System;

namespace ConestogaVirtualGameStore.Data
{
    /// <summary>
    /// The genders that a user may choose from.
    /// </summary>
    public enum Gender { Other = 0, Male = 1, Female = 2 }

    /// <summary>
    /// A registered/authorized user in the application.
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
    }
}
