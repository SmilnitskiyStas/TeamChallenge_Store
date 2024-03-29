using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamChallengeProject_Shop.Models;

namespace TeamChallengeProject_Shop.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products").HasKey(p => p.ProductId);
            builder.Property(p => p.ProductId).HasColumnName("ProductId").HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasColumnName("Name").HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(p => p.Description).HasColumnName("Description").HasColumnType("text");
            builder.Property(p => p.Price).HasColumnName("Price").HasColumnType("money").IsRequired();
            builder.Property(p => p.Quantity).HasColumnName("Quantity").HasColumnType("int").IsRequired();
            builder.Property(p => p.PickUp).HasColumnName("PickUp").HasColumnType("bool").IsRequired();
            builder.Property(p => p.Delivery).HasColumnName("Delivery").HasColumnType("bool").IsRequired();
            builder.Property(p => p.Created_at).HasColumnName("Created_at").HasColumnType("datetime").IsRequired();
            builder.Property(p => p.Delete_at).HasColumnName("Delete_at").HasColumnType("datetime");
            builder.Property(p => p.StoreId).HasColumnName("StoreId").HasColumnType("int");

            builder.HasOne(p => p.Store)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.StoreId)
                .OnDelete(DeleteBehavior.Cascade)       // Видалення із бази
                .HasPrincipalKey(s => s.StoreId);       // Посилання на пов'язану сутність в іншій таблиці (Stores=>StoreId)
        }
    }
}
