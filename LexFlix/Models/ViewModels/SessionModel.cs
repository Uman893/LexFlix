using LexFlix.Models;
using System.ComponentModel.DataAnnotations;

namespace LexFlix.Models.ViewModels
{
    public class SessionModel
    {
        public int Movieid { get; set; }
        [Display(Name = "Empty")]
        public string Title { get; set; }

        public string Director { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice //This is the individual total price in Order Details
        { 
            get 
            {
                return Price * Quantity; // "computed property", Counts the Price with the quantity automatically here.
            } 
        }

        public SessionModel()
        {

        }

        public SessionModel(int movieid, string title, string director, int quantity, decimal price)
        {
            Movieid = movieid;
            Title = title;
            Director = director;
            Quantity = quantity;
            Price = price;
            
        }
    }
}