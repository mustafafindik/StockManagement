namespace StockManagement.Core.CrossCuttingConcerns.Caching
{
    /// <summary>
    /// Burada Cache ile ilgili metodlar var.
    /// Cache T generic şeklide, obje şeklikde dönebilir.
    /// </summary>
    public interface ICacheService
    {
        /// <summary>
        ///  T Generic tipinde Cache verisi döner.
        /// </summary>
        /// <typeparam name="T">Generic Sınıf</typeparam>
        /// <param name="key">Cache Key'i</param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">Cache Key'i</param>
        /// <returns></returns>
        object Get(string key);

        /// <summary>
        /// burada Cache data eklemek için
        /// </summary>
        /// <param name="key">datayı çagırmak için Key</param>
        /// <param name="data">Cachelenecek daha</param>
        /// <param name="duration">Ne kadar kalsın Cache'de</param>
        void Add(string key, object data, int duration);

        /// <summary>
        ///  verilen Keye göre bellekte cache var mı?
        /// </summary>
        /// <param name="key"> Çagrılan Cache Keyi</param>
        /// <returns>Cache var yada yok</returns>
        bool IsAdd(string key);

        /// <summary>
        /// Cache yi silmek için. Genelde veri eklendiğinde yada güncellendiğinde
        /// </summary>
        /// <param name="key">Cache Keyi</param>
        void Remove(string key);

        /// <summary>
        /// Belirli paterne göre Silme işlemi yapar
        /// </summary>
        /// <param name="pattern">verilecek patern.</param>
        void RemoveByPattern(string pattern);
    }
}
