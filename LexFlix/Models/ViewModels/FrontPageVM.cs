namespace LexFlix.Models.ViewModels
{
    public class FrontPageVM
    {
        public List<Movies> GeneralMovieList { get; set; }
        public List<Movies> Old5MovieList { get; set; }
        public List<Movies> New5MovieList { get; set; }
        public List<Movies> Cheap5MovieList { get; set; }
        public List<Movies> PopularMovieList { get; set; }
        public List<BestCustomerVM> BestCustomer { get; set; }

        public FrontPageVM()
        {
            GeneralMovieList = new List<Movies>();
            Old5MovieList = new List<Movies>();
            New5MovieList = new List<Movies>();
            Cheap5MovieList = new List<Movies>();
            PopularMovieList = new List<Movies>();  
            BestCustomer = new List<BestCustomerVM>(); 
        }
    }
}
