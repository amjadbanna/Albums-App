using AlbumsApp.Entities;

namespace AlbumsApp.Models
{
    public class AlbumsViewModel
    {
        public ICollection<string>? Genres { get; set; }

        public ICollection<Album>? Albums { get; set; }

        public string? ActiveGenre { get; set; }

        public Album? RandomAlbum { get; set; }
        
        
        public Album? NewAlbum { get; set; }
    }
}
