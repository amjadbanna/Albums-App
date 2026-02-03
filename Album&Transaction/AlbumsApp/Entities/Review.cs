using System.ComponentModel.DataAnnotations;

namespace AlbumsApp.Entities
{
    public class Review
    {
        public int? Rating { get; set; }



        public string? Comments { get; set; }
    }
}
