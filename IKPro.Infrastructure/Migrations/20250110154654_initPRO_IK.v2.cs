using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IKPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initPRO_IKv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paketler",
                columns: table => new
                {
                    PaketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaketAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaketSuresi = table.Column<int>(type: "int", nullable: false),
                    YayinlanmaTarihi = table.Column<DateTime>(type: "date", maxLength: 50, nullable: false),
                    YayindanKaldirilmaTarihi = table.Column<DateTime>(type: "date", maxLength: 50, nullable: false),
                    Fiyat = table.Column<decimal>(type: "money", maxLength: 50, nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    KullaniciSayisi = table.Column<int>(type: "int", nullable: false),
                    ParaBirimi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paketler", x => x.PaketID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sirketler",
                columns: table => new
                {
                    SirketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Unvan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MersisNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VergiNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VergiDairesi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CalisanSayisi = table.Column<int>(type: "int", nullable: false),
                    KurulusYili = table.Column<short>(type: "smallint", maxLength: 50, nullable: false),
                    SozlesmeBaslangic = table.Column<DateTime>(type: "date", maxLength: 50, nullable: false),
                    SozlesmeBitis = table.Column<DateTime>(type: "date", maxLength: 50, nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    PaketID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sirketler", x => x.SirketID);
                    table.ForeignKey(
                        name: "FK_Sirketler_Paketler_PaketID",
                        column: x => x.PaketID,
                        principalTable: "Paketler",
                        principalColumn: "PaketID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IkinciAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IkinciSoyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fotograf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TcNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumYeri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "date", nullable: false),
                    IseGirisTarih = table.Column<DateTime>(type: "date", nullable: false),
                    IstenCikisTarihi = table.Column<DateTime>(type: "date", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Meslek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departman = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Maas = table.Column<decimal>(type: "money", nullable: true),
                    SirketID = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Sirketler_SirketID",
                        column: x => x.SirketID,
                        principalTable: "Sirketler",
                        principalColumn: "SirketID");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvansTalepleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TalepTarihi = table.Column<DateTime>(type: "date", maxLength: 50, nullable: false),
                    OnayDurumu = table.Column<int>(type: "int", nullable: false),
                    CevaplanmaTarihi = table.Column<DateTime>(type: "date", maxLength: 50, nullable: true),
                    Tutar = table.Column<decimal>(type: "money", nullable: false),
                    ParaBirimi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AvansTuru = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvansTalepleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvansTalepleri_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HarcamaTalepleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HarcamaTuru = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParaBirimi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OnayDurumu = table.Column<int>(type: "int", nullable: false),
                    TalepTarihi = table.Column<DateTime>(type: "date", maxLength: 50, nullable: false),
                    CevaplanmaTarihi = table.Column<DateTime>(type: "date", maxLength: 50, nullable: true),
                    DosyaEkleme = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Tutar = table.Column<decimal>(type: "money", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HarcamaTalepleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HarcamaTalepleri_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IzinTalepleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IzinTuru = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "date", maxLength: 50, nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "date", maxLength: 50, nullable: false),
                    TalepTarihi = table.Column<DateTime>(type: "date", maxLength: 50, nullable: false),
                    GunSayisi = table.Column<short>(type: "smallint", nullable: false),
                    CevaplanmaTarihi = table.Column<DateTime>(type: "date", maxLength: 50, nullable: true),
                    OnayDurumu = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzinTalepleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IzinTalepleri_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "d8ad8fca-4a39-46e1-925d-d298903e2c8f", "Admin", "ADMIN" },
                    { 2, "deb4d581-15b2-48a4-b95c-b0e95953a6f6", "SirketYonetici", "SIRKETYONETICI" },
                    { 3, "b7f6f537-1701-4c83-90ce-cb36d548b769", "Personel", "PERSONEL" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adi", "Adres", "Aktif", "ConcurrencyStamp", "Departman", "DogumTarihi", "DogumYeri", "Email", "EmailConfirmed", "Fotograf", "IkinciAdi", "IkinciSoyadi", "IseGirisTarih", "IstenCikisTarihi", "LockoutEnabled", "LockoutEnd", "Maas", "Meslek", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SirketID", "Soyadi", "TcNo", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "Super", "Root", true, "d13f9f7f-3e53-4b4c-aec1-fe18dc24a2af", "admin", new DateTime(2025, 1, 10, 18, 46, 53, 579, DateTimeKind.Local).AddTicks(222), "tr", "pro@admin.com", false, "foto.jpg", null, null, new DateTime(2025, 1, 10, 18, 46, 53, 579, DateTimeKind.Local).AddTicks(235), new DateTime(2025, 1, 10, 18, 46, 53, 579, DateTimeKind.Local).AddTicks(236), false, null, null, "Admin", "PRO@ADMIN.COM", "ADMINPRO", "AQAAAAIAAYagAAAAEOka1ZTFw2gCmunNfSwVSRYiB9EIaUlZtOYcre5hAmNzItiB/SHAPvHH4yShbDqfFw==", "05555555555", false, "d1febbe3-9dcc-46aa-be21-13f928c6b34a", null, "Admin", "11111111111", false, "AdminPro" },
                    { 2, 0, "John", "New York", true, "0b1f412f-3582-45ca-b7af-1e91e545fc0f", "IT", new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "us", "john.doe@example.com", true, "john_doe.jpg", null, null, new DateTime(2015, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 18, 46, 53, 659, DateTimeKind.Local).AddTicks(2471), false, null, null, "Developer", "JOHN.DOE@EXAMPLE.COM", "JOHN_DOE", "AQAAAAIAAYagAAAAEH+oX333Xri7F7SQgW0bA9H/Cw0Nk018x67Vvic7ut981YNpyohwiJTHEP68DhHZfg==", "05555555556", false, "72aeacf1-7d80-4832-a7a3-47f30c8c6d11", null, "Doe", "22222222222", false, "john_doe" },
                    { 3, 0, "Jane", "Los Angeles", false, "16a78f35-f328-48b7-95f7-3ee53089211c", "HR", new DateTime(1985, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "us", "jane.smith@example.com", true, "jane_smith.jpg", null, null, new DateTime(2010, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "HR Specialist", "JANE.SMITH@EXAMPLE.COM", "JANE_SMITH", "AQAAAAIAAYagAAAAEJ7Tw+j/OT5sKsY+7qnPYNYbEAuvLzCs3tpx8DKTi+zwvgS+TqRUxmD0ZDOIfg91nw==", "05555555557", false, "d93aedd5-33da-4e76-b398-336694ec4a9f", null, "Smith", "33333333333", false, "jane_smith" }
                });

            migrationBuilder.InsertData(
                table: "Paketler",
                columns: new[] { "PaketID", "Aktif", "Fiyat", "KullaniciSayisi", "PaketAdi", "PaketSuresi", "ParaBirimi", "YayindanKaldirilmaTarihi", "YayinlanmaTarihi" },
                values: new object[] { 1, true, 799.99m, 500, "Business Paket", 24, "TRY", new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Sirketler",
                columns: new[] { "SirketID", "Ad", "Adres", "Aktif", "CalisanSayisi", "Email", "KurulusYili", "Logo", "MersisNo", "PaketID", "SozlesmeBaslangic", "SozlesmeBitis", "Telefon", "Unvan", "VergiDairesi", "VergiNo" },
                values: new object[] { 1, "x", "Kadıköy", true, 4, "sirket@mail.com", (short)2024, "logo.png", "12345678901", 1, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "11111111111", "LTD", "Kadıköy Vergi Dairesi", "123412341234" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SirketID",
                table: "AspNetUsers",
                column: "SirketID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AvansTalepleri_AppUserId",
                table: "AvansTalepleri",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HarcamaTalepleri_AppUserId",
                table: "HarcamaTalepleri",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IzinTalepleri_AppUserId",
                table: "IzinTalepleri",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sirketler_PaketID",
                table: "Sirketler",
                column: "PaketID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AvansTalepleri");

            migrationBuilder.DropTable(
                name: "HarcamaTalepleri");

            migrationBuilder.DropTable(
                name: "IzinTalepleri");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Sirketler");

            migrationBuilder.DropTable(
                name: "Paketler");
        }
    }
}
