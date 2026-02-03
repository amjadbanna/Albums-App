using Microsoft.AspNetCore.Mvc;

using AlbumsApp.Services;
using AlbumsApp.Models;
using AlbumsApp.Entities;

namespace AlbumsApp.Controllers
{
    public class AlbumController : Controller
    {
        public AlbumController(IAlbumManager albumManager)
        {
            _albumManager = albumManager;
        }

        [HttpGet("/albums/{genre?}")]
        public IActionResult GetAlbums(string? genre)
        {
            ICollection<Album> albums = null;
            if (string.IsNullOrEmpty(genre) || genre == "All")
            {
                albums = _albumManager.GetAllAlbums();
                genre = "All";
            }
            else
            {
                albums = _albumManager.GetAlbumsByGenre(genre);
            }

            AlbumsViewModel albumsViewModel = new AlbumsViewModel() { 
                Genres = _albumManager.GetAllGenres(),
                Albums = albums,
                ActiveGenre = genre,
                RandomAlbum = _albumManager.GetRandomAlbum()
            };

            return View("List", albumsViewModel);
        }

        [HttpGet("/album/{id}")]
        public IActionResult GetAlbumById(int id)
        {
            Album? album = _albumManager.GetAlbumById(id);
            if (album == null)
            {
                return NotFound();
            }
            
            return View("Details", album);
        }

        [HttpPost("/albums")]
        public IActionResult AddNewAlbum(AlbumsViewModel albumsViewModel)
        {
            string activeGenre = string.IsNullOrEmpty(albumsViewModel.ActiveGenre) ? "All" : albumsViewModel.ActiveGenre;
            
            if (!ModelState.IsValid)
            {
                albumsViewModel.ActiveGenre = activeGenre;
                albumsViewModel.RandomAlbum = _albumManager.GetRandomAlbum();
                albumsViewModel.Genres = _albumManager.GetAllGenres();

                if (activeGenre == "All")
                {
                    albumsViewModel.Albums = _albumManager.GetAllAlbums();
                }
                else
                {
                    albumsViewModel.Albums = _albumManager.GetAlbumsByGenre(activeGenre);
                }
                
                return View("List", albumsViewModel);
            }
            
            _albumManager.AddAlbum(albumsViewModel.NewAlbum);
            TempData["LastActionMessage"] = $"Album {albumsViewModel.NewAlbum} was added";
            return RedirectToAction("GetAlbums", "Album", new { genre = activeGenre });
        }

        private IAlbumManager _albumManager;
    }
}
