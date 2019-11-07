using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class RemovedFriendshipDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "74d2c27e-952d-407c-b575-891591a86ee7", new DateTime(2019, 11, 7, 15, 20, 36, 4, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEHc3Mlpuw4Uixfwdm1LHaAso7x+cZjJ4A/N8Z/W5MKj9juhXDdQwlMoCtEG4jxJOsw==", "9b5e774e-41dd-42df-914a-4ebd288fdeac" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "027fbc97-a874-401d-8cd7-82472ae1ae06", new DateTime(2019, 11, 7, 15, 20, 36, 6, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEKTb6qzt3saJY1A8LVGkVp5OptXSp7KXVdeWlHb0xk/RKWmghMZPG7op57WummFSiQ==", "756d769a-51e0-4421-a715-9cd775446575" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
