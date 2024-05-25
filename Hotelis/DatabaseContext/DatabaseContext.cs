using Hotelis.Model;
using Microsoft.EntityFrameworkCore;


namespace Hotelis.DatabaseContext
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hotel>().HasData(

                    new Hotel
                    {
                        HotelID = 1,
                        HotelName = "Radisson",
                        Country = "Lithuania",
                        City = "Kaunas",
                        Street = "Donelaicio",
                        Number = "27",
                    },
                    new Hotel
                    {
                        HotelID = 2,
                        HotelName = "Grand Hotel Kempinski",
                        Country = "Lithuania",
                        City = "Vilnius",
                        Street = "Universiteto",
                        Number = "14",
                    },
                    new Hotel
                    {
                        HotelID = 3,
                        HotelName = "Holiday Inn",
                        Country = "Lithuania",
                        City = "Vilnius",
                        Street = "Seimyniskiu",
                        Number = "1",
                    },
                    new Hotel
                    {
                        HotelID = 4,
                        HotelName = "Amberton Hotel",
                        Country = "Lithuania",
                        City = "Klaipeda",
                        Street = "Naujojo Sodo",
                        Number = "1",
                    },
                    new Hotel
                    {
                        HotelID = 5,
                        HotelName = "Artis Centrum Hotels",
                        Country = "Lithuania",
                        City = "Vilnius",
                        Street = "Liejyklos",
                        Number = "11",
                    },
                    new Hotel
                    {
                        HotelID = 6,
                        HotelName = "Hotel Congress Avenue",
                        Country = "Lithuania",
                        City = "Vilnius",
                        Street = "Gedimino pr.",
                        Number = "12",
                    },
                    new Hotel
                    {
                        HotelID = 7,
                        HotelName = "Europa Royale",
                        Country = "Lithuania",
                        City = "Kaunas",
                        Street = "Misko",
                        Number = "11",
                    },
                    new Hotel
                    {
                        HotelID = 8,
                        HotelName = "Park Inn by Radisson",
                        Country = "Lithuania",
                        City = "Kaunas",
                        Street = "K. Donelaicio",
                        Number = "27",
                    },
                    new Hotel
                    {
                        HotelID = 9,
                        HotelName = "Novotel Vilnius Centre",
                        Country = "Lithuania",
                        City = "Vilnius",
                        Street = "Gedimino pr.",
                        Number = "16",
                    },
                    new Hotel
                    {
                        HotelID = 10,
                        HotelName = "Vanagupe Hotel",
                        Country = "Lithuania",
                        City = "Palanga",
                        Street = "Vanagupes",
                        Number = "31",
                    },
                    new Hotel
                    {
                        HotelID = 11,
                        HotelName = "Neringa Hotel",
                        Country = "Lithuania",
                        City = "Vilnius",
                        Street = "Gedimino pr.",
                        Number = "23",
                    },
                    new Hotel
                    {
                        HotelID = 12,
                        HotelName = "Hotel Euterpe",
                        Country = "Lithuania",
                        City = "Klaipeda",
                        Street = "Darzu",
                        Number = "9",
                    },
                    new Hotel
                    {
                        HotelID = 13,
                        HotelName = "Moon Garden Art Hotel",
                        Country = "Lithuania",
                        City = "Vilnius",
                        Street = "Bazilijonu",
                        Number = "10",
                    },
                    new Hotel
                    {
                        HotelID = 14,
                        HotelName = "Urbihop Hotel",
                        Country = "Lithuania",
                        City = "Vilnius",
                        Street = "A. Vienuolio",
                        Number = "8",
                    },
                    new Hotel
                    {
                        HotelID = 15,
                        HotelName = "Best Baltic Hotel Palanga",
                        Country = "Lithuania",
                        City = "Palanga",
                        Street = "Gintaro",
                        Number = "36",
                    },
                    new Hotel
                    {
                        HotelID = 16,
                        HotelName = "Daugirdas Old City Hotel",
                        Country = "Lithuania",
                        City = "Kaunas",
                        Street = "T. Daugirdo",
                        Number = "4",
                    },
                    new Hotel
                    {
                        HotelID = 17,
                        HotelName = "Hotel Pacai",
                        Country = "Lithuania",
                        City = "Vilnius",
                        Street = "Didzioji",
                        Number = "7",
                    },
                    new Hotel
                    {
                        HotelID = 18,
                        HotelName = "Hotel Vandenis",
                        Country = "Lithuania",
                        City = "Palanga",
                        Street = "Birutes al.",
                        Number = "47",
                    },
                    new Hotel
                    {
                        HotelID = 19,
                        HotelName = "Best Western Vilnius",
                        Country = "Lithuania",
                        City = "Vilnius",
                        Street = "Konstitucijos pr.",
                        Number = "14",
                    },
                    new Hotel
                    {
                        HotelID = 20,
                        HotelName = "Memel Hotel",
                        Country = "Lithuania",
                        City = "Klaipeda",
                        Street = "Bangu",
                        Number = "4",
                    });
            string imagesDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "images"));
            modelBuilder.Entity<Image>().HasData(

                new Image {ImageID=1, HotelID = 1, ImagePath = Path.Combine(imagesDirectory, "Radisson.jpg") },
                new Image { ImageID = 2,HotelID = 2, ImagePath = Path.Combine(imagesDirectory, "GrandHotelKempinski.jpg") },
                new Image {ImageID = 3, HotelID = 3, ImagePath = Path.Combine(imagesDirectory, "HolidayInn.jpg") },
                new Image {ImageID = 4, HotelID = 4, ImagePath = Path.Combine(imagesDirectory, "AmbertonHotel.jpg") },
                new Image {ImageID = 5, HotelID = 5, ImagePath = Path.Combine(imagesDirectory, "ArtisCentrumHotel.jpg") },
                new Image {ImageID = 6, HotelID = 6, ImagePath = Path.Combine(imagesDirectory, "HotelCongressAvenue.jpg") },
                new Image {ImageID = 7, HotelID = 7, ImagePath = Path.Combine(imagesDirectory, "EuropaRoyale.jpg") },
                new Image {ImageID = 8, HotelID = 8, ImagePath = Path.Combine(imagesDirectory, "ParkInn.jpg") },
                new Image {ImageID = 9, HotelID = 9, ImagePath = Path.Combine(imagesDirectory, "NovotelVilnius.jpg") },
                new Image {ImageID = 10, HotelID = 10, ImagePath = Path.Combine(imagesDirectory, "Venagupe.jpg") },
                new Image {ImageID = 11, HotelID = 11, ImagePath = Path.Combine(imagesDirectory, "NeringaHotel.jpg") },
                new Image {ImageID = 12, HotelID = 12, ImagePath = Path.Combine(imagesDirectory, "EuterpeHotel.jpg") },
                new Image {ImageID = 13, HotelID = 13, ImagePath = Path.Combine(imagesDirectory, "MoonGardenArtHotel.jpg") },
                new Image {ImageID = 14, HotelID = 14, ImagePath = Path.Combine(imagesDirectory, "UrbihopHotel.jpg") },
                new Image {ImageID = 15, HotelID = 15, ImagePath = Path.Combine(imagesDirectory, "BestBalticHotel.jpg") },
                new Image {ImageID = 16, HotelID = 16, ImagePath = Path.Combine(imagesDirectory, "DaugirdasOldCityHotel.jpg") },
                new Image {ImageID = 17, HotelID = 17, ImagePath = Path.Combine(imagesDirectory, "HotelPacai.jpg") },
                new Image { ImageID = 18, HotelID = 18, ImagePath = Path.Combine(imagesDirectory, "Vandenis.jpg") },
                new Image {ImageID = 19, HotelID = 19, ImagePath = Path.Combine(imagesDirectory, "BestWesternVilnius.jpg") },
                new Image {ImageID = 20, HotelID = 20, ImagePath = Path.Combine(imagesDirectory, "MemelHotel.jpg") }

                );
        }


        public DbSet<Hotel> Hotels { get;set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
