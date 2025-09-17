using IKPro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IKPro.Infrastructure.ModelConfigurations
{
    public class Paket_CFG : IEntityTypeConfiguration<Paket>
    {
        public void Configure(EntityTypeBuilder<Paket> builder)
        {
            builder.Property(x => x.PaketAdi)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(x => x.Fiyat)
                   .HasColumnType("money")
                   .HasMaxLength(50);
            builder.Property(x => x.YayinlanmaTarihi)
                   .HasColumnType("date")
                   .HasMaxLength(50);
            builder.Property(x => x.YayindanKaldirilmaTarihi)
                   .HasColumnType("date")
                   .HasMaxLength(50);
            builder.Property(x => x.ParaBirimi)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(50);
            Paket paket = new Paket()
            {
                PaketID = 1,
                PaketAdi = "Business Paket",
                PaketSuresi = 24,  
                YayinlanmaTarihi = new DateTime(2023, 6, 1),  
                YayindanKaldirilmaTarihi = new DateTime(2026, 6, 1),  
                Fiyat = 799.99m,
                Aktif = true,  
                KullaniciSayisi = 500, 
                ParaBirimi = "TRY", 
            };
            builder.HasData(paket);
        }
    }
}
