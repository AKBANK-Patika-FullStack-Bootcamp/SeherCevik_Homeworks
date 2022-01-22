namespace RestaurantFinder.Helpers
{
    public class AppSettings
    {
        // appsetting.json dosyasında ki verileri bir class yardımıyla programımızın içerisinde kullanmak için yazdığımız sınıfıtır. 
        //appsetting.json içerisinde oluşturduğumuz bu sınıfla aynı isimdeki section(bölüm) içindeki token ı üretmek  ve kontrol etmek için için kullanacağımız secret key ide prop olarak tanımladık.

        public string? Secret { get; set; }
        
    }
}
