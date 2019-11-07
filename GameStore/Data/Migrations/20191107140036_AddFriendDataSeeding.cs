using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class AddFriendDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Friendship",
                columns: new[] { "SenderId", "ReceiverId", "IsFamily", "RequestStatus" },
                values: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", "2a2a222-222-22aa-222a-a22aa2a22aa2", false, 1 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0672d3c4-2952-492d-b3b0-2e4c24e6083b", new DateTime(2019, 11, 7, 14, 0, 36, 195, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEHTJkov5pBlqJDYY2fSxFEyJTNiKT1qMq3Qgjf/cYrqASYjkxc6hmZLazDJ1T7DMUQ==", "6e0a1376-7f24-42c3-befe-7196cbbaf539" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3809110-1e29-4fe7-847d-699d9a9bb817", new DateTime(2019, 11, 7, 14, 0, 36, 196, DateTimeKind.Utc), "AQAAAAEAACcQAAAAENWUlTqqVBJ1dsdqkLs2h9cMcdDEPD+FOU/ff/FMMExJyHxZ43knghNUk8FlwclVLg==", "e23ccfe6-824f-4155-9d7a-204b11232ea3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Friendship",
                keyColumns: new[] { "SenderId", "ReceiverId" },
                keyValues: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", "2a2a222-222-22aa-222a-a22aa2a22aa2" });

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
    }
}
