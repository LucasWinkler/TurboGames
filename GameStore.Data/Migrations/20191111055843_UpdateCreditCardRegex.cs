using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class UpdateCreditCardRegex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "Payment",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash" },
                values: new object[] { "a12cdaec-ea66-4bd6-9ce7-dba67c7ce965", new DateTime(2019, 11, 11, 5, 58, 42, 754, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEHG1HuSUzNQb16bTORqyz5FQwWKvlSgv3oueYgRrrmHj3SCFSyMVwIBbkcPLBJUEwQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b865abe4-fb32-4e80-aae8-ec707d107271", "AQAAAAEAACcQAAAAEPjT2DDJqnBQGKJSSLAHSO1mM1iOtjHDFHbGCSq4EfLq+jPLY9h5V5NEEXsQWzAZiA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "Payment",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash" },
                values: new object[] { "8a11b8e4-8d51-4bc1-849c-8dfe12ad964a", new DateTime(2019, 11, 11, 2, 49, 34, 322, DateTimeKind.Utc), "AQAAAAEAACcQAAAAELF5NOM/jsp7Q+s71A8AM9UsbVZppZXW20bibOmFArOPKHHAOaIh89JtXEb+SOf/+Q==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "26945383-7d44-4e5f-8dd3-5caf4d0df921", "AQAAAAEAACcQAAAAEP6xQitYc6KN1wp6pUvJz2Ku6gzSbrtdrZSO+6iofnWFVHXOV6XwWfj9DK3atsv0xQ==" });
        }
    }
}
