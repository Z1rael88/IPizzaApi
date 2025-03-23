using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class ChosenIngredientConfiguration : IEntityTypeConfiguration<ChosenIngredient>
{
    public void Configure(EntityTypeBuilder<ChosenIngredient> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Ingredient)
            .WithMany()
            .HasForeignKey(x => x.IngredientId);
        builder.Property(x => x.TotalPrice)
            .IsRequired();
        builder.Property(x => x.Quantity)
            .IsRequired();
    }
}
