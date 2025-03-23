using Infrastructure.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class OrderedPizzaConfiguration : BaseModelConfiguration<OrderedPizza>
{
    public override void Configure(EntityTypeBuilder<OrderedPizza> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.PizzaId).IsRequired();
        builder.Property(x => x.Sum).IsRequired();
    }
}