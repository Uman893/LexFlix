using LexFlix.Models;
using LexFlix.Models.ViewModels;
using System.Reflection.Metadata.Ecma335;

namespace LexFlix.Models.ViewModels
{
    public class CartVM
  {        
     public List<SessionModel> Movies  { get; set; }

        public decimal SumOfAllPrice { 
            get 
            {
                return Movies.Sum(m => m.TotalPrice); // "computed property", This is what counts the total price of all movies in Shoppingcart 
            }
        }
        public CartVM()
        {
        Movies = new List<SessionModel>();
        }
        public List<SessionModel> GetMovies()
        {
            return Movies;
        }
        public SessionModel GetMovie(int id)
        {
            foreach(SessionModel movie in Movies)
            {
                if(movie.Movieid == id)
                {
                    return movie; 
                }             
            }
            return null;
        }
      
  }
}
