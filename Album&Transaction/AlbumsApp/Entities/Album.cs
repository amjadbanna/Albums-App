using System.ComponentModel.DataAnnotations;

namespace AlbumsApp.Entities
{
    public class Album
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "What artist created the album?")]
        public string Artist { get; set; }
        

        [Required(ErrorMessage = "What is the name of the album?")]
        public string Title { get; set; }
        

        [Required(ErrorMessage = "What year was the album produced?")]
        public int? Year { get; set; }
        

        //[Required(ErrorMessage = "What is the genre of the album?")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Genre must be between 2 and 100 characters")]
        public string Genre { get; set; }

        public string? CoverImageUrl { get; set; }

        public override string ToString()
        {
            return $"\"{Title}\" by {Artist} ({Year})";
        }

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
