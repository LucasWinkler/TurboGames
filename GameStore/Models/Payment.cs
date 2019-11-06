﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class Payment
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Card name")]
        public string CardName { get; set; }

        [Required]
        [DataType(DataType.CreditCard)]
        [Display(Name = "Card number")]
        [RegularExpression(@"^((4\d{3})|(5[1-5]\d{2})|(6011))-?\d{4}-?\d{4}-?\d{4}|3[4,7]\d{13}$", ErrorMessage = "Card number is invalid.")]
        public string CardNumber { get; set; }

        [Required]
        [Display(Name = "Expiration date (MM/YY)")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^((0[1-9])|(1[0-2]))\/(\d{2})$", ErrorMessage = "Expiration date must match MM/YY (example: 06/22).")]
        public string CardExpirationDate { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "CVC")]
        [StringLength(4, ErrorMessage = "CVC can not be more than 4 digits.")]
        [RegularExpression(@"^([0-9]{3,4})$", ErrorMessage = "CVC must be 3 or 4 digits.")]
        public string CardCVC { get; set; }
    }
}