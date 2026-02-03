using AlbumsApp.Entities;

namespace AlbumsApp.Services
{
    public class AlbumManager : IAlbumManager
    {
        public AlbumManager()
        {
            // Seed data, first genres:
            _allGenres.Add("Rock");
            _allGenres.Add("Folk");
            _allGenres.Add("Classical");
            _allGenres.Add("Country");
            _allGenres.Add("Rap");

            // And then some albums:
            Album album1 = new Album() {Id = 1, Artist = "The Beatles", Title = "Sgt. Pepper's Lonely Hearts Club Band", Year = 1967, Genre = "Rock", CoverImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/50/Sgt._Pepper%27s_Lonely_Hearts_Club_Band.jpg"};
            Album album2 = new Album() {Id = 2, Artist = "The Beatles", Title = "Let It Be", Year = 1970, Genre = "Rock", CoverImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/7a/The_Beatles_-_Let_It_Be.png" };
            Album album3 = new Album() {Id = 3, Artist = "The Rolling Stones", Title = "Let It Bleed", Year = 1969, Genre = "Rock", CoverImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/c0/LetitbleedRS.jpg" };
            Album album4 = new Album() {Id = 4, Artist = "The Clash", Title = "London Calling", Year = 1979, Genre = "Rock", CoverImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/00/TheClashLondonCallingalbumcover.jpg" };
            Album album5 = new Album() {Id = 5, Artist = "Bob Dylan", Title = "Bringing It All Back Home", Year = 1965, Genre = "Folk", CoverImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b1/Bob_Dylan_-_Bringing_It_All_Back_Home.jpg" };
            Album album6 = new Album() {Id = 6, Artist = "Glenn Gould", Title = "J. S. Bach: The Goldberg Variations", Year = 1955, Genre = "Classical", CoverImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e4/BachTheGoldbergVariations-GlennGould.jpg" };
            Album album7 = new Album() {Id = 7, Artist = "Johnny Cash", Title = "At Folsum Prison", Year = 1968, Genre = "Country", CoverImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bf/Johnny_Cash_At_Folsom_Prison.jpg" };
            
            album1.Reviews.Add(new Review() { Rating = 5, Comments = "A game changer!! Literally changed the entire industry"});
            album1.Reviews.Add(new Review() { Rating = 4, Comments = "A bit sad because it marked the end of their touring days"});

            album6.Reviews.Add(new Review() { Rating = 5, Comments = "Brilliant!"});
            album6.Reviews.Add(new Review() { Rating = 3, Comments = "I like the later recording better"});
            
            _albums.Add(album1);
            _albums.Add(album2);
            _albums.Add(album3);
            _albums.Add(album4);
            _albums.Add(album5);
            _albums.Add(album6);
            _albums.Add(album7);
        }

        public void AddAlbum(Album album)
        {
            // first get an ID..
            if (_albums.Any())
            {
                album.Id = _albums.Max(a => a.Id) + 1;
            }
            else
            {
                album.Id = 1;
            }
            
            // then add it
            _albums.Add(album);
        }

        public ICollection<Album> GetAllAlbums()
        {
            return _albums.AsReadOnly();
        }

        public ICollection<Album> GetAlbumsByGenre(string genre)
        {
            return _albums.Where(a => a.Genre == genre).ToList();
        }

        public Album? GetRandomAlbum()
        {
            if (_albums.Count == 0)
                return null;
            
            Random r = new Random();
            int randomIndex = r.Next(0, _albums.Count);
            return _albums[randomIndex];
        }

        public Album? GetAlbumById(int id)
        {
            return _albums.FirstOrDefault(a => a.Id == id);
        }

        public ICollection<string> GetAllGenres()
        {
            return _allGenres.AsReadOnly();
        }

        private List<string> _allGenres = new List<string>();

        private List<Album> _albums = new List<Album>();
    }
}
