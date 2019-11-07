using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class AddBillingSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "PostalCode", "PrimaryAddress", "Province", "SecondaryAddress" },
                values: new object[] { new Guid("0c3e6619-7425-40de-944b-e07fc1f90ae7"), "Cambridge", "Canada", "N1P1H1", "57 Kingsboro Road", "Ontario", null });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "Id", "CardCVC", "CardExpirationDate", "CardName", "CardNumber" },
                values: new object[] { new Guid("1c3e6619-7425-40de-944b-e07fc1f90ae7"), "313", "11/21", "Lucas Winkler", "4123450131003312" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1",
                columns: new[] { "AddressId", "ConcurrencyStamp", "DOB", "PasswordHash", "PaymentId", "SecurityStamp" },
                values: new object[] { new Guid("0c3e6619-7425-40de-944b-e07fc1f90ae7"), "2f4611ee-f064-4109-9da2-9e44aae318cf", new DateTime(2019, 11, 7, 22, 30, 0, 445, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEJReIqhQaoTIFEab0ru3ruOXRZfJqHkcqMUvUsSCMql5sbCbYgfxlTXH5aBNfDyXFA==", new Guid("1c3e6619-7425-40de-944b-e07fc1f90ae7"), "28815b6e-b447-4d8e-924d-6405d879237d" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "AddressId", "ConcurrencyStamp", "DOB", "PasswordHash", "PaymentId", "SecurityStamp" },
                values: new object[] { new Guid("0c3e6619-7425-40de-944b-e07fc1f90ae7"), "cfb5cb4a-5500-42e7-a73f-9ff4cbadf6d3", new DateTime(2019, 11, 7, 22, 30, 0, 452, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEHDjKnjquui/AkPpTMh4l8cZe8ZAaEwM/y5+usXVJnJoLiXKC6RqmX1q837SbYSVlw==", new Guid("1c3e6619-7425-40de-944b-e07fc1f90ae7"), "9c003b05-c23b-48dc-8e0d-1f5ea1bda2e7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: new Guid("0c3e6619-7425-40de-944b-e07fc1f90ae7"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "Id",
                keyValue: new Guid("1c3e6619-7425-40de-944b-e07fc1f90ae7"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1",
                columns: new[] { "AddressId", "ConcurrencyStamp", "DOB", "PasswordHash", "PaymentId", "SecurityStamp" },
                values: new object[] { null, "74d2c27e-952d-407c-b575-891591a86ee7", new DateTime(2019, 11, 7, 15, 20, 36, 4, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEHc3Mlpuw4Uixfwdm1LHaAso7x+cZjJ4A/N8Z/W5MKj9juhXDdQwlMoCtEG4jxJOsw==", null, "9b5e774e-41dd-42df-914a-4ebd288fdeac" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "AddressId", "ConcurrencyStamp", "DOB", "PasswordHash", "PaymentId", "SecurityStamp" },
                values: new object[] { null, "027fbc97-a874-401d-8cd7-82472ae1ae06", new DateTime(2019, 11, 7, 15, 20, 36, 6, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEKTb6qzt3saJY1A8LVGkVp5OptXSp7KXVdeWlHb0xk/RKWmghMZPG7op57WummFSiQ==", null, "756d769a-51e0-4421-a715-9cd775446575" });
        }
    }
}
