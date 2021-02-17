using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework.Builders
{
    public class StockBuilder : IEntityTypeConfiguration<Stock>
    {
        /// <summary>
        ///  Barcode Sınıfı için Veritabanı Ayarları
        ///  Haskey = Primary Key
        /// IsRequired  = Zorunlu
        /// HasMaxLenght = Max Karakter Sayısı
        ///  StockType ile Stock  Bir'e çok ilişki StockType Tek , Stock Çok
        ///  Product ile Stock  Bir'e çok ilişki Product Tek , Stock Çok
        /// </summary>
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.StockType).WithMany(c => c.Stocks).HasForeignKey(p => p.StockTypeId);
            builder.HasOne(p => p.Product).WithMany(c => c.Stocks).HasForeignKey(p => p.ProductId);
            builder.Property(p => p.Quantity).HasColumnType("decimal(18,2)");
        }
    }
}
