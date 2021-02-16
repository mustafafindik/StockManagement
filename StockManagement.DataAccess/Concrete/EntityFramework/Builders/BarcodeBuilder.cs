using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework.Builders
{
    /// <summary>
    ///  Barcode Sınıfı için Veritabanı Ayarları
    ///  Haskey = Primary Key
    /// IsRequired  = Zorunlu
    /// HasMaxLenght = Max Karakter Sayısı
    ///  Product ile Barcode Arasında Bir'e çok ilişki Product Tek , Barcode Çok
    /// </summary>
    public class BarcodeBuilder : IEntityTypeConfiguration<Barcode>
    {
        public void Configure(EntityTypeBuilder<Barcode> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.BarcodeNumber).IsRequired().HasMaxLength(20);
            builder.HasOne(p => p.Product).WithMany(c => c.Barcodes).HasForeignKey(p => p.ProductId);
        }
    }
}
