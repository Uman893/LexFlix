

using System.ComponentModel.DataAnnotations;

namespace LexFlix.Models
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string ImageURL { get; set; }


        public virtual List<OrderRows> OrderRows { get; set; }
        //public virtual ICollection<OrderRows> OrderRows { get; set; }

        public Movies()
        {

        }

        public Movies(int id, string title, string director, int releaseYear, decimal price, string imageURL)
        {
            Id = id;
            Title = title;
            Director = director;
            ReleaseYear = releaseYear;
            Price = price;
            ImageURL = imageURL;
        }   
    }


}
