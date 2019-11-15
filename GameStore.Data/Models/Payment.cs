using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Data.Models
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
        [RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|6(?:011|5[0-9]{2})[0-9]{12}|(?:2131|1800|35\d{3})\d{11})$", ErrorMessage = "Card number is invalid or unsupported.")]
        [MaxLength(16, ErrorMessage = "Card number is invalid or unsupported.")]
        public string CardNumber { get; set; }

        [Required]
        [Display(Name = "Expiration date")]
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
