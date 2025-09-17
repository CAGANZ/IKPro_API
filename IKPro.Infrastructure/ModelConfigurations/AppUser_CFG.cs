using IKPro.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IKPro.Infrastructure.ModelConfigurations
{
    public class AppUser_CFG : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Adi)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(x => x.IkinciAdi)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(50);
            builder.Property(x => x.Soyadi)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(x => x.IkinciSoyadi)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(50);
            builder.Property(x => x.Adres)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(250)
                   .IsRequired();
            builder.Property(x => x.IseGirisTarih).HasColumnType("date").IsRequired();
            builder.Property(x => x.IstenCikisTarihi).HasColumnType("date");
            builder.Property(x => x.DogumTarihi).HasColumnType("date").IsRequired();
            builder.Property(x => x.Maas).HasColumnType("money");

            AppUser user = new AppUser()
            {
                Id = 1,
                Adi = "Super",
                Soyadi = "Admin",
                Adres = "Root",
                UserName = "AdminPro",
                NormalizedUserName = "ADMINPRO",
                Email = "pro@admin.com",
                NormalizedEmail = "PRO@ADMIN.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = false,
                Departman = "admin",
                Fotograf = "foto.jpg",
                TcNo = "11111111111",
                DogumYeri = "tr",
                DogumTarihi = DateTime.Now,
                IseGirisTarih = DateTime.Now,
                IstenCikisTarihi = DateTime.Now,
                Aktif = true,
                Meslek = "Admin",
                PhoneNumber = "05555555555",
            };
            PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();
            user.PasswordHash = hasher.HashPassword(user, "Admin.123");
            builder.HasData(user);

            AppUser sirketYonetici = new AppUser()
            {
                Id = 2,
                Adi = "John",
                Soyadi = "Doe",
                Adres = "New York",
                UserName = "john_doe",
                NormalizedUserName = "JOHN_DOE",
                Email = "john.doe@example.com",
                NormalizedEmail = "JOHN.DOE@EXAMPLE.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                Departman = "IT",
                Fotograf = "john_doe.jpg",
                TcNo = "22222222222",
                DogumYeri = "us",
                DogumTarihi = new DateTime(1990, 5, 15),
                IseGirisTarih = new DateTime(2015, 6, 1),
                IstenCikisTarihi = DateTime.Now,
                Aktif = true,
                Meslek = "Developer",
                PhoneNumber = "05555555556",
            };
            sirketYonetici.PasswordHash = hasher.HashPassword(sirketYonetici, "Yonetici.123");
            builder.HasData(sirketYonetici);

            AppUser personel = new AppUser()
            {
                Id = 3,
                Adi = "Jane",
                Soyadi = "Smith",
                Adres = "Los Angeles",
                UserName = "jane_smith",
                NormalizedUserName = "JANE_SMITH",
                Email = "jane.smith@example.com",
                NormalizedEmail = "JANE.SMITH@EXAMPLE.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                Departman = "HR",
                Fotograf = "jane_smith.jpg",
                TcNo = "33333333333",
                DogumYeri = "us",
                DogumTarihi = new DateTime(1985, 7, 20),
                IseGirisTarih = new DateTime(2010, 4, 10),
                IstenCikisTarihi = new DateTime(2023, 12, 31),
                Aktif = false,
                Meslek = "HR Specialist",
                PhoneNumber = "05555555557",
            };
            personel.PasswordHash = hasher.HashPassword(personel, "Personel.123");
            builder.HasData(personel);
        }

        
    }
}
