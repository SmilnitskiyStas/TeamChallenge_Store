using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamChallengeProject_Shop.Models;

namespace TeamChallengeProject_Shop.Config
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories").HasKey(pc => pc.ProductCategoryId);
            builder.Property(pc => pc.ProductCategoryId).HasColumnName("ProductCategoryId").HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(pc => pc.ProductId).HasColumnName("ProductId").HasColumnType("int");
            builder.Property(pc => pc.CategoryId).HasColumnName("CategoryId").HasColumnType("int");

            builder.HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategory)
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategory)
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
