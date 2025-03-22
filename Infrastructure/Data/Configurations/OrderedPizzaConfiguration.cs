using Infrastructure.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class OrderedPizzaConfiguration : BaseModelConfiguration<OrderedPizza>
{
    public override void Configure(EntityTypeBuilder<OrderedPizza> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.TotalPrice)
            .IsRequired();
        builder.Property(x => x.OrderId).IsRequired();
        builder.Property(x => x.PizzaId).IsRequired();
    }
}