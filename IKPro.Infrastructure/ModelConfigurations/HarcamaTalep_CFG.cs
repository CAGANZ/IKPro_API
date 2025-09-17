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
    public class HarcamaTalep_CFG : IEntityTypeConfiguration<HarcamaTalep>
    {
        public void Configure(EntityTypeBuilder<HarcamaTalep> builder)
        {
            builder.Property(x => x.TalepTarihi)
                   .HasColumnType("date")
                   .HasMaxLength(50); 
            builder.Property(x => x.CevaplanmaTarihi)
                   .HasColumnType("date")
                   .HasMaxLength(50);
            builder.Property(x => x.ParaBirimi)
                  .HasColumnType("nvarchar")
                  .HasMaxLength(50);
            builder.Property(x => x.HarcamaTuru)
                  .HasColumnType("nvarchar")
                  .HasMaxLength(50);
            builder.Property(x => x.DosyaEkleme)
                  .HasColumnType("nvarchar")
                  .HasMaxLength(500);   /////
            builder.Property(x => x.Tutar)
                .HasColumnType("money");
        }
    }
}
