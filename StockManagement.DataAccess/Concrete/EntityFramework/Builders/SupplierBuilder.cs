using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework.Builders
{
    class SupplierBuilder : IEntityTypeConfiguration<Supplier>
    {
        /// <summary>
        ///  Barcode Sınıfı için Veritabanı Ayarları
        ///  Haskey = Primary Key
        /// IsRequired  = Zorunlu
        /// HasMaxLenght = Max Karakter Sayısı
        /// </summary>
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.SupplierName).IsRequired().HasMaxLength(200);


        }
    }
}
