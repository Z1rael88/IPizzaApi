using Infrastructure.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class OrderConfiguration : BaseModelConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.OrderedPizzasIds)
            .IsRequired();
        builder.HasMany(x => x.OrderedPizzas)
            .WithOne()
            .HasForeignKey(x => x.OrderId);
        builder.ComplexProperty(x => x.Address)
            .IsRequired();
    }
}