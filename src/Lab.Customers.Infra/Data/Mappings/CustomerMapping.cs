using Lab.Core.Commons.ValueObjects;
using Lab.Customers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.Customers.Infra.Data.Mappings;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.BirthDate)
            .IsRequired()
            .HasColumnName("BirthDate")
            .HasColumnType("date");

        builder.OwnsOne(c => c.Name, tf =>
        {
            tf.Property(c => c.FirstName)
                .IsRequired()
                .HasColumnName("FirstName")
                .HasColumnType("varchar(60)");

            tf.Property(c => c.LastName)
                .IsRequired()
                .HasColumnName("LastName")
                .HasColumnType("varchar(60)");
        });

        builder.OwnsOne(c => c.Cpf, tf =>
        {
            tf.Property(c => c.Number)
                .IsRequired()
                .HasMaxLength(Cpf.MaxLength)
                .HasColumnName("Cpf")
                .HasColumnType($"varchar({Cpf.MaxLength})");
        });
    }
}