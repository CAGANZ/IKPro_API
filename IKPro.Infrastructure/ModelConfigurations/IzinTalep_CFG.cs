using IKPro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPro.Infrastructure.ModelConfigurations
{
    public class IzinTalep_CFG : IEntityTypeConfiguration<IzinTalep>
    {
        public void Configure(EntityTypeBuilder<IzinTalep> builder)
        {
            builder.Property(x => x.BaslangicTarihi)
                   .HasColumnType("date")
                   .HasMaxLength(50); 
            builder.Property(x => x.BitisTarihi)
                   .HasColumnType("date")
                   .HasMaxLength(50); 
            builder.Property(x => x.CevaplanmaTarihi)
                   .HasColumnType("date")
                   .HasMaxLength(50);
            builder.Property(x => x.TalepTarihi)
                   .HasColumnType("date")
                   .HasMaxLength(50);
            builder.Property(x => x.IzinTuru)
                  .HasColumnType("nvarchar")
                  .HasMaxLength(50);
            builder.Property(x => x.GunSayisi)
                  .HasColumnType("smallint")
                  .IsRequired();
        }
    }
}
