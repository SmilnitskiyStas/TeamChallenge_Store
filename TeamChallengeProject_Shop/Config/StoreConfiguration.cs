using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamChallengeProject_Shop.Models;

namespace TeamChallengeProject_Shop.Config
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Stores").HasKey(s => s.StoreId);
            builder.Property(s => s.StoreId).HasColumnName("StoreId").HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(s => s.Name).HasColumnName("Name").HasColumnType("nvarchar(30)").IsRequired();
            builder.Property(s => s.Create_at).HasColumnName("Create_at").HasColumnType("datetime").IsRequired();
            builder.Property(s => s.Delete_at).HasColumnName("Delete_at").HasColumnType("datetime");
        }
    }
}
