using CaixaDomain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaixaData.Mapping
{
    public class NotasMap : IEntityTypeConfiguration<Notas>
    {
        public void Configure(EntityTypeBuilder<Notas> builder)
        {
            builder.ToTable("Notas");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Valor)
                .IsRequired()
                .HasColumnName("Valor")
                .HasColumnType("decimal(10,2)");

            builder.Property(prop => prop.Quantidade)
               .IsRequired()
               .HasColumnName("Quantidade")
               .HasColumnType("int");

            builder.Property(prop => prop.DataAtualizacao)
                .IsRequired()
                .HasColumnName("DataAtualizacao")
                .HasColumnType("datetime");
        }
    }
}
