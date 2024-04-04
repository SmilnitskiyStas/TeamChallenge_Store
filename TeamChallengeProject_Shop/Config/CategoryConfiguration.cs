using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamChallengeProject_Shop.Models;

namespace TeamChallengeProject_Shop.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories").HasKey(c => c.CategoryId);
            builder.Property(c => c.CategoryId).HasColumnName("CategoryId").HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(c => c.Name).HasColumnName("Name").HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(c => c.ParentId).HasColumnName("ParentId").HasColumnType("int");

            //builder.HasOne(c => c.ProductCategory)
            //    .WithMany(pc => pc.Categories)
            //    .HasForeignKey(c => c.CategoryId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
