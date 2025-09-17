using IKPro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace IKPro.Infrastructure.ModelConfigurations
{
    public class AppRole_CFG : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(
                new AppRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() },
                new AppRole { Id = 2, Name = "SirketYonetici", NormalizedName = "SIRKETYONETICI", ConcurrencyStamp = Guid.NewGuid().ToString() },
                new AppRole { Id = 3, Name = "Personel", NormalizedName = "PERSONEL", ConcurrencyStamp = Guid.NewGuid().ToString() }
                );
        }
    }
}
