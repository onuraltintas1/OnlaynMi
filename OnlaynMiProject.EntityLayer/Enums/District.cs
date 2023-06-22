namespace OnlaynMiProject.EntityLayer.Enums;

public class District
{
    public static Dictionary<City, List<string>> IllerVeIlceler = new Dictionary<City, List<string>>
    {
        { City.Ankara, new List<string> { "Çankaya", "Keciören", "Mamak", "Yenimahalle" } },
        { City.Antalya, new List<string> { "Muratpaşa", "Kepez", "Konyaaltı", "Aksu" } },
        { City.Bursa, new List<string> { "Osmangazi", "Nilüfer", "Yıldırım", "Gürsu" } },
        { City.Eskisehir, new List<string> { "Odunpazarı", "Tepebaşı", "Çankaya", "Yenikent" } },
        { City.Istanbul, new List<string> { "Kadıköy", "Beşiktaş", "Üsküdar", "Sarıyer" } },
        { City.Izmir, new List<string> { "Karşıyaka", "Bornova", "Buca", "Konak" } },
        { City.Kocaeli, new List<string> { "İzmit", "Gebze", "Darıca", "Çayırova" } }
    };

}