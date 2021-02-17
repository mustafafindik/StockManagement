using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework.Builders
{


    public class ProductBuilder : IEntityTypeConfiguration<Product>
    {
        /// <summary>
        ///  Barcode Sınıfı için Veritabanı Ayarları
        ///  Haskey = Primary Key
        /// IsRequired  = Zorunlu
        /// HasMaxLenght = Max Karakter Sayısı
        ///  Product ile Subcategory Arasında Bir'e çok ilişki Product Çok , Subcategory tek
        /// Product ile Subcategory Arasında Bir'e çok ilişki Product Çok , Subcategory tek
        /// Product ile Unit Arasında Bir'e çok ilişki Product Çok , Unit tek
        /// Product ile SalesVatRate Arasında Bir'e çok ilişki Product Çok , SalesVatRate tek
        /// Product ile Warehouse Arasında Bir'e çok ilişki Product Çok , Warehouse tek
        /// Product ile PurchaseVatRate Arasında Bir'e çok ilişki Product Çok , PurchaseVatRate tek
        /// </summary>
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ProductName).IsRequired().HasMaxLength(200);
            builder.Property(p => p.ProductCode).IsRequired().HasMaxLength(200);
            builder.HasOne(p => p.SubCategory).WithMany(c => c.Products).HasForeignKey(p => p.SubCategoryId);
            builder.HasOne(p => p.Unit).WithMany(c => c.Products).HasForeignKey(p => p.UnitId);
            builder.HasOne(p => p.SalesVatRate).WithMany().HasForeignKey(p => p.SalesVatRateId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Warehouse).WithMany(c => c.Products).HasForeignKey(p => p.WarehouseId);
            builder.HasOne(p => p.PurchaseVatRate).WithMany().HasForeignKey(p => p.PurchaseVatRateId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(p => p.PurchasePrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.SalePrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Sim).HasColumnType("decimal(18,2)");

        }
    }


}
