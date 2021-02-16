using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework.Builders
{
    public class VatRateBuilder : IEntityTypeConfiguration<VatRate>
    {

        /// <summary>
        ///  Barcode Sınıfı için Veritabanı Ayarları
        ///  Haskey = Primary Key
        /// IsRequired  = Zorunlu
        /// HasMaxLenght = Max Karakter Sayısı
        /// </summary>
        public void Configure(EntityTypeBuilder<VatRate> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.VatRateName).IsRequired().HasMaxLength(200);
        }
    }
}
