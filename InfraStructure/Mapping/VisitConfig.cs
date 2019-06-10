using ViajaNet.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraStructure.Mapping
{
    public class VisitConfig : IEntityTypeConfiguration<Visit>
    {

        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.Property(_ => _.Url)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(_ => _.Browser)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(_ => _.Ip)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(_ => _.PageParams)
                .IsRequired()
                .HasColumnType("varchar(MAX)");
        }
    }
}
