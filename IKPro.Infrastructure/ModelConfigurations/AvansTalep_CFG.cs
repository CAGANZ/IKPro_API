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
    public class AvansTalep_CFG : IEntityTypeConfiguration<AvansTalep>
    {
        public void Configure(EntityTypeBuilder<AvansTalep> builder)
        {
            builder.Property(x => x.CevaplanmaTarihi)
                 .HasColumnType("date")
                 .HasMaxLength(50);
            builder.Property(x => x.TalepTarihi)
                 .HasColumnType("date")
                 .HasMaxLength(50);
            builder.Property(x => x.ParaBirimi)
                  .HasColumnType("nvarchar")
                  .HasMaxLength(50);
            builder.Property(x => x.Aciklama)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(250);
            builder.Property(x => x.AvansTuru)
                  .HasColumnType("nvarchar")
                  .HasMaxLength(50);
            builder.Property(x => x.Tutar)
                   .HasColumnType("money");
        }
    }
}
