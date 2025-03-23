using Infrastructure.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class PizzaConfiguration : BaseModelConfiguration<Pizza>
{
    public override void Configure(EntityTypeBuilder<Pizza> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.PhotoUrl)
            .IsRequired();
        builder.Property(x => x.Name)
            .IsRequired();
        builder.Property(x => x.Ingredientsids).IsRequired();
        builder.Property(x => x.Size)
            .IsRequired();
        builder.Property(x => x.Dough)
            .IsRequired();
        builder.Property(x => x.Price)
            .IsRequired();
    }
}