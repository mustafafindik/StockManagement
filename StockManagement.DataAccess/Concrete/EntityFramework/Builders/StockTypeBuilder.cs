using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework.Builders
{
    public class StockTypeBuilder : IEntityTypeConfiguration<StockType>
    {
        /// <summary>
        ///  Barcode Sınıfı için Veritabanı Ayarları
        ///  Haskey = Primary Key
        /// IsRequired  = Zorunlu
        /// HasMaxLenght = Max Karakter Sayısı
        /// </summary>
        public void Configure(EntityTypeBuilder<StockType> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.StockTypeName).IsRequired().HasMaxLength(200);

        }
    }
}
