using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class DroppedUserGameDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7") });

            migrationBuilder.DeleteData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7") });

            migrationBuilder.DeleteData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9bfed2c-b558-436c-899a-a2bf99a0a182", new DateTime(2019, 11, 7, 13, 30, 18, 171, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEEEtqz7ZX70f5P5RYgemvoEEUbfp38flQ4PreF0azD8Qyx02YlRxcqFHjfpzukXq/g==", "20b1e1db-5902-40e1-870c-4deaf5a30806" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66233a57-55c1-4139-962c-9bdb1bac14b4", new DateTime(2019, 11, 7, 13, 30, 18, 172, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEFWeb3fVTgT0BJASwFeUyzZwu+Mppuy05LPzT96aF6OKe0hYPoIQ0zPsHdPrTVGV/A==", "242acaee-9263-4d78-b3f2-5630ff5a8923" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5f3dfe2-68cf-44be-960c-83c9dddb987a", new DateTime(2019, 11, 7, 10, 47, 58, 560, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEOfkoZ+jTA2BDzHhK7uXTrd4XUuK21g/PXryZv9VbEv5+lNb8sBURxV95iZ9DiVsJA==", "2961fb9e-8a2a-4603-9dcc-e490477f5ef1" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f860af26-eac4-498f-9b3e-104c9cd74465", new DateTime(2019, 11, 7, 10, 47, 58, 562, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEGcf3k3RHA4kTOrKzExG+sMCc2EOiO92MvQGVfXAnIuAXMlXVfXRpKdxN5pG9a7SOw==", "6d48aff4-3b2d-4d97-9693-d721ae239de4" });

            migrationBuilder.InsertData(
                table: "UserGame",
                columns: new[] { "UserId", "GameId", "PurchaseDate" },
                values: new object[,]
                {
                    { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7"), new DateTime(2019, 11, 7, 10, 47, 58, 562, DateTimeKind.Utc) },
                    { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7"), new DateTime(2019, 11, 7, 10, 47, 58, 562, DateTimeKind.Utc) },
                    { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7"), new DateTime(2019, 11, 7, 10, 47, 58, 562, DateTimeKind.Utc) }
                });
        }
    }
}
