using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework.Builders
{
    public class SubCategoryBuilder : IEntityTypeConfiguration<SubCategory>
    {
        /// <summary>
        ///  Barcode Sınıfı için Veritabanı Ayarları
        ///  Haskey = Primary Key
        /// IsRequired  = Zorunlu
        /// HasMaxLenght = Max Karakter Sayısı
        ///  SubCategory ile Category  Bir'e çok ilişki Category Tek , SubCategories Çok
        /// </summary>
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.SubCategoryName).IsRequired().HasMaxLength(200);
            builder.HasOne(p => p.Category).WithMany(c => c.SubCategories).HasForeignKey(p => p.CategoryId);

        }
    }
}
