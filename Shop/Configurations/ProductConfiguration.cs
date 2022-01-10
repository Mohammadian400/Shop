using Shop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.Configurations
{
    public class ProductConfiguration: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.ProductName).HasMaxLength(30).IsRequired();
            builder.Property(p => p.BrandName).HasMaxLength(30);
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            //builder.Property(p => p.RegisterDate).IsRequired();
            

            // relations
            builder.HasOne(p => p.Category).WithMany(p => p.Products).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
