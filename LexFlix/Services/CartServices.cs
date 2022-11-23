using LexFlix.Data;
using LexFlix.Models.ViewModels;
using LexFlix.Helper;
using LexFlix.Exceptions;

namespace LexFlix.Services
{
    public class CartServices : ICartServices
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CartServices> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;       

        const string SessionKeyUsername = "SessionKeyUsername";
        const string SessionKeyCart = "ShoppingCart";
        public CartServices(ApplicationDbContext context, ILogger<CartServices> logger, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        public void RemoveSessionFromCart(int id)
        {
            CartVM sessionObject = _httpContextAccessor.HttpContext.Session.Get<CartVM>(SessionKeyCart);

            var newMovies = new List<SessionModel>();

            foreach (var item in sessionObject.Movies)

                if (item.Movieid != id) newMovies.Add(item);

            sessionObject.Movies = newMovies;

            _httpContextAccessor.HttpContext.Session.Set<CartVM>(SessionKeyCart, sessionObject);
        }
        public void IncrementSessionFromCart(int Id)
        {
            CartVM sessionObject = _httpContextAccessor.HttpContext.Session.Get<CartVM>(SessionKeyCart);
            var movie = _context.Movies.Find(Id);
            var existingMovie = sessionObject.Movies.FirstOrDefault(m => m.Movieid == Id);
            if (existingMovie != null)
            {
                ++existingMovie.Quantity;
            }

            _httpContextAccessor.HttpContext.Session.Set<CartVM>(SessionKeyCart, sessionObject);
        }
        public void DecrementSessionFromCart(int Id)
        {
            CartVM sessionObject = _httpContextAccessor.HttpContext.Session.Get<CartVM>(SessionKeyCart);
            var movie = _context.Movies.Find(Id);
            var existingMovie = sessionObject.Movies.FirstOrDefault(m => m.Movieid == Id);
            if (existingMovie != null)
            {
                --existingMovie.Quantity;
            }

            if (existingMovie.Quantity < 1)
                throw new EmptyCartException();
            

            _httpContextAccessor.HttpContext.Session.Set<CartVM>(SessionKeyCart, sessionObject);
        }      
        public void AddSessionToCart(int Id)
        {
            if (_httpContextAccessor.HttpContext.Session.Get<CartVM>(SessionKeyCart) == default)
            {
                _httpContextAccessor.HttpContext.Session.Set<CartVM>(SessionKeyCart, new CartVM());
            }

            CartVM sessionObject = _httpContextAccessor.HttpContext.Session.Get<CartVM>(SessionKeyCart);
            var movie = _context.Movies.Find(Id);

            if (movie != null)
            {
              
                var existingMovie = sessionObject.Movies.FirstOrDefault(m => m.Movieid == Id);
                if (existingMovie != null)
                {
                    ++existingMovie.Quantity;               
                    _httpContextAccessor.HttpContext.Session.Set<CartVM>(SessionKeyCart, sessionObject);
                    throw new AddToCartException();                   
                }
                else
                {
                    sessionObject.Movies.Add(new SessionModel
                    {
                        Movieid = movie.Id,
                        Director = movie.Director,
                        Quantity = 1,
                        Title = movie.Title,
                        Price = movie.Price,
                    });
                }
            }
            _httpContextAccessor.HttpContext.Session.Set<CartVM>(SessionKeyCart, sessionObject);
        }
    }
}
