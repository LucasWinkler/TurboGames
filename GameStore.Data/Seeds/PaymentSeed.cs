using GameStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GameStore.Data.Seeds
{
    public static class PaymentSeed
    {
        public static void SeedPayments(this ModelBuilder builder)
        {
            builder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = Guid.Parse("1c3e6619-7425-40de-944b-e07fc1f90ae7"),
                    CardNumber = "4123450131003312",
                    CardCVC = "313",
                    CardExpirationDate = "11/21",
                    CardName = "Lucas Winkler"
                }
            );
        }
    }
}
