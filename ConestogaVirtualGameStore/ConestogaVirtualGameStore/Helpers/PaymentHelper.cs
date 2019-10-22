using System;
using System.Text.RegularExpressions;

namespace ConestogaVirtualGameStore.Helpers
{
    /// <summary>
    /// Validates the type of any supported payment cards
    /// </summary>
    public class PaymentHelper
    {
        /// <summary>
        /// The supported card types
        /// </summary>
        public enum CardType
        {
            Visa = 0,
            MasterCard = 1
        }

        /// <summary>
        /// Gets the payment cards type
        /// </summary>
        /// <param name="cardNumber">The cards number</param>
        /// <returns>The card type or throw exception if invalid/unsupported card</returns>
        public static CardType GetType(string cardNumber)
        {
            if (Regex.Match(cardNumber, @"^4[0-9]{12}(?:[0-9]{3})?$").Success)
            {
                return CardType.Visa;
            }
            else if (Regex.Match(cardNumber, @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$").Success)
            {
                return CardType.MasterCard;
            }

            throw new Exception("Unsupported/invalid card type.");
        }
    }

}
