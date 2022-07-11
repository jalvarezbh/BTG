using CaixaDomain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaixaData.Mapping
{   
    public class SaquesMap : IEntityTypeConfiguration<Saques>
    {
        public void Configure(EntityTypeBuilder<Saques> builder)
        {
            builder.ToTable("Saques");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Valor)
                .IsRequired()
                .HasColumnName("Valor")
                .HasColumnType("decimal(10,2)");

            builder.Property(prop => prop.QuantidadeNotas)
               .IsRequired()
               .HasColumnName("QuantidadeNotas")
               .HasColumnType("int");

            builder.Property(prop => prop.Data)
                .IsRequired()
                .HasColumnName("Data")
                .HasColumnType("datetime");
        }
    }
}
