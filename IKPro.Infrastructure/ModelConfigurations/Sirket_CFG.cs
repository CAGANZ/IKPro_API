using IKPro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IKPro.Infrastructure.ModelConfigurations
{
    public class Sirket_CFG : IEntityTypeConfiguration<Sirket>
    {
        public void Configure(EntityTypeBuilder<Sirket> builder)
        {
            builder.Property(x => x.Ad)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(x => x.Unvan)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(x => x.MersisNo)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(x => x.VergiNo)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(x => x.VergiDairesi)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(x => x.Logo)
                   .HasColumnType("nvarchar")
                   .HasMaxLength (4000)
                   .IsRequired();
            builder.Property(x => x.Telefon)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(20)
                   .IsRequired();
            builder.Property(x => x.Adres)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(350)
                   .IsRequired();
            builder.Property(x => x.Email)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(x => x.KurulusYili)
                   .HasColumnType("smallint")
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(x => x.SozlesmeBaslangic)
                   .HasColumnType("date")
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(x => x.SozlesmeBitis)
                   .HasColumnType("date")
                   .HasMaxLength(50);
            Sirket sirket = new Sirket()
            {
                SirketID = 1,
                Ad = "x",
                Telefon = "11111111111",
                Adres = "Kadıköy",
                Unvan = "LTD",
                Aktif = true,
                MersisNo = "12345678901",
                VergiDairesi = "Kadıköy Vergi Dairesi",
                CalisanSayisi = 4,
                VergiNo = "123412341234",
                Email = "sirket@mail.com",
                KurulusYili = 2024,
                SozlesmeBaslangic = new DateTime(2024, 1, 3),
                SozlesmeBitis = new DateTime(2025, 1, 3),
                Logo = "logo.png",
                PaketID = 1
            };
            builder.HasData(sirket);

        }
    }
}
