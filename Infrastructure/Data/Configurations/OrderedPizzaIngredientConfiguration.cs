using Infrastructure.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class OrderedPizzaIngredientConfiguration : BaseModelConfiguration<OrderedPizzaIngredients>
{
    public override void Configure(EntityTypeBuilder<OrderedPizzaIngredients> builder)
    {
        base.Configure(builder);
        builder.HasOne(x => x.Ingredient)
            .WithMany()
            .HasForeignKey(x => x.IngredientId);
        builder.HasOne(x => x.OrderedPizza)
            .WithMany()
            .HasForeignKey(x => x.OrderedPizzaId);
    }
}