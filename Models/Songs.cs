namespace MusicShopProject.Models
{
    public class Songs
    {
        public required int SongsID { get; set; }

        public required string Name { get; set; }

        public required string Artist { get; set; }

        public required string Genre { get; set; }

        public required string Date_Added { get; set; }

        public required decimal Song_Length { get; set; }

        public required decimal Download_Size { get; set; }

        public required decimal Price { get; set; }
    }
}
