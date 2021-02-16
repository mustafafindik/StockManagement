using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework.Builders
{
    public class WarehouseBuilder : IEntityTypeConfiguration<Warehouse>
    {
        /// <summary>
        ///  Barcode Sınıfı için Veritabanı Ayarları
        ///  Haskey = Primary Key
        /// IsRequired  = Zorunlu
        /// HasMaxLenght = Max Karakter Sayısı
        ///  City ile  Warehouse Bir'e çok ilişki City Tek , Warehouse Çok
        /// </summary>
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.WarehouseName).IsRequired().HasMaxLength(200);
            builder.HasOne(p => p.City).WithMany(c => c.Warehouses).HasForeignKey(p => p.CityId);
        }
    }
}
