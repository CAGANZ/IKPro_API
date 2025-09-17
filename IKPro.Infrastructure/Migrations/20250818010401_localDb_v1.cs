using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IKPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class localDb_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ea1539a5-28df-4eef-9fb6-68756a9db09b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e21cafc7-3869-48be-a1f9-3a0fbab0d6fe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "b408d6e9-c192-4a4b-9dab-fdcc2187a4bc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DogumTarihi", "IseGirisTarih", "IstenCikisTarihi", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ec2116a-6582-4e64-927b-88098d1d353d", new DateTime(2025, 8, 18, 4, 3, 59, 968, DateTimeKind.Local).AddTicks(1615), new DateTime(2025, 8, 18, 4, 3, 59, 968, DateTimeKind.Local).AddTicks(1634), new DateTime(2025, 8, 18, 4, 3, 59, 968, DateTimeKind.Local).AddTicks(1635), "AQAAAAIAAYagAAAAEP5FaKfcMsggAO3UgphUW+Swl6y+5Ef+5wSeyhw9owIrC+anGuzK3nRuxuXgOfbziA==", "726ce810-97cd-4e51-a85e-f370b8ddf4ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "IstenCikisTarihi", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a91da9e4-08ba-4499-8488-dd822d411c4b", new DateTime(2025, 8, 18, 4, 4, 0, 68, DateTimeKind.Local).AddTicks(6361), "AQAAAAIAAYagAAAAEMg9BVWr1lrneNk6Wiv2LJd/2jMTnovRFVL4N8KVavQtG/JpyeX5gtqLKCKXL/pTSQ==", "cc0c81b1-c7fc-4593-91b4-643b44a0b969" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16b5489e-e747-4772-b944-49a1228959b0", "AQAAAAIAAYagAAAAEDy2+qj2cxxARPTjcv56iksppbHkavQlqV2xAkialzu9ZYw+iMr7M1O7TeONebTzNA==", "602d5dbf-b7d0-495d-9ee1-3e5d2860a0fd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d8ad8fca-4a39-46e1-925d-d298903e2c8f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "deb4d581-15b2-48a4-b95c-b0e95953a6f6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "b7f6f537-1701-4c83-90ce-cb36d548b769");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DogumTarihi", "IseGirisTarih", "IstenCikisTarihi", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d13f9f7f-3e53-4b4c-aec1-fe18dc24a2af", new DateTime(2025, 1, 10, 18, 46, 53, 579, DateTimeKind.Local).AddTicks(222), new DateTime(2025, 1, 10, 18, 46, 53, 579, DateTimeKind.Local).AddTicks(235), new DateTime(2025, 1, 10, 18, 46, 53, 579, DateTimeKind.Local).AddTicks(236), "AQAAAAIAAYagAAAAEOka1ZTFw2gCmunNfSwVSRYiB9EIaUlZtOYcre5hAmNzItiB/SHAPvHH4yShbDqfFw==", "d1febbe3-9dcc-46aa-be21-13f928c6b34a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "IstenCikisTarihi", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b1f412f-3582-45ca-b7af-1e91e545fc0f", new DateTime(2025, 1, 10, 18, 46, 53, 659, DateTimeKind.Local).AddTicks(2471), "AQAAAAIAAYagAAAAEH+oX333Xri7F7SQgW0bA9H/Cw0Nk018x67Vvic7ut981YNpyohwiJTHEP68DhHZfg==", "72aeacf1-7d80-4832-a7a3-47f30c8c6d11" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16a78f35-f328-48b7-95f7-3ee53089211c", "AQAAAAIAAYagAAAAEJ7Tw+j/OT5sKsY+7qnPYNYbEAuvLzCs3tpx8DKTi+zwvgS+TqRUxmD0ZDOIfg91nw==", "d93aedd5-33da-4e76-b398-336694ec4a9f" });
        }
    }
}
