﻿using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ConestogaVirtualGameStore.Models
{
    public class Payment
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [ProtectedPersonalData]
        [DataType(DataType.Text)]
        [Display(Name = "Card name")]
        public string CardName { get; set; }

        [ProtectedPersonalData]
        [DataType(DataType.Text)]
        [Display(Name = "Card type")]
        public string CardType { get; set; }

        [Required]
        [ProtectedPersonalData]
        [DataType(DataType.Text)]
        [Display(Name = "Card number")]
        public string CardNumber { get; set; }

        [Required]
        [ProtectedPersonalData]
        [DataType(DataType.Date)]
        [Display(Name = "Card expiration date")]
        public DateTime CardExpirationDate { get; set; }
    }
}
