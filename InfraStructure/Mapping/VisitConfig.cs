using ViajaNet.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CsvHelper.Configuration;

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

    public class VisitMap : ClassMap<Visit>
    {
        public VisitMap()
        {
            Map(m => m.Id).Index(0).Name("Id");
            Map(m => m.Url).Index(1).Name("Url");
            Map(m => m.Ip).Index(2).Name("Ip");
            Map(m => m.Browser).Index(3).Name("Browser");
            Map(m => m.PageParams).Index(4).Name("Parâmetros");
        }
    }
}
