using AlbumsApp.Entities;
using AlbumsApp.Models;
using AlbumsApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlbumsApp.Controllers;

[ApiController()]
public class AlbumsApiController : ControllerBase
{
    public AlbumsApiController(IAlbumManager albumManager)
    {
        _albumManager = albumManager;
    }

    [HttpGet("/api/albums")]
    public IActionResult GetAllMovies()
    {
        ICollection<Album> albums = _albumManager.GetAllAlbums();
        return Ok(albums);
    }

    [HttpGet("/api/albums/{id}")]
    public IActionResult GetMovieById(int id)
    {
        Album? album = _albumManager.GetAlbumById(id);
        if (album == null)
            return NotFound();
        
        return Ok(album);
    }

    [HttpGet("/api/albums/{id}/reviews")]
    public IActionResult GetReviewsByMovieId(int id)
    {
        Album? album = _albumManager.GetAlbumById(id);
        if (album == null)
            return NotFound();
        
        return Ok(album.Reviews);
    }

    [HttpPost("{id}/reviews")]
    public IActionResult PostReview(int id, [FromBody] ReviewInputModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        
        var album = _albumManager.GetAlbumById(id);
        if (album == null)
        {
            return NotFound($"Album with id {id} not found");
        }

        var newReview = new Review
        { 

            Rating = model.Rating,
            Comments = model.Content

        };

        album.Reviews.Add(newReview);

        return Ok(newReview);
    }

    private IAlbumManager  _albumManager;
}