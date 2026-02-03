using System.ComponentModel.DataAnnotations;

namespace AlbumsApp.Models
{
    public class ReviewInputModel
    {

        [Required]
        public string Content { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        public string ReviewerName {  get; set; }


    }
}
