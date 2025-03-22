using Infrastructure.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class IngredientConfiguration : BaseModelConfiguration<Ingredient>
{
    public override void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Price)
            .IsRequired();
        builder.Property(x => x.Name)
            .IsRequired();
        builder.Property(x => x.IngredientType)
            .IsRequired();
    }
}