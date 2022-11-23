using LexFlix.Data;
using LexFlix.Exceptions;
using LexFlix.Helper;
using LexFlix.Models;
using LexFlix.Models.ViewModels;
using LexFlix.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LexFlix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly ICartServices _cartServices;

        const string SessionKeyUsername = "SessionKeyUsername";
        const string SessionKeyCart = "ShoppingCart";
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context,
            ICartServices cartServices)
        {
            _logger = logger;
            _context = context;
            _cartServices = cartServices;
        }
        public IActionResult Index()
        {
            FrontPageVM frontPage = new();

            frontPage.GeneralMovieList = _context.Movies.ToList();

            frontPage.New5MovieList = _context.Movies.OrderByDescending(m => m.ReleaseYear).Take(5).ToList();

            frontPage.Old5MovieList = _context.Movies.OrderBy(m => m.ReleaseYear).Take(5).ToList();

            frontPage.Cheap5MovieList = _context.Movies.OrderBy(m => m.Price).Take(5).ToList();

            var popularMovies = _context.Movies
               .Include(o => o.OrderRows)
               .OrderByDescending(o => o.OrderRows.Count(m => m.MovieId == m.MovieId)).Take(5)
               .Select(s => new Movies()
               {
                   Id = s.Id,
                   Title = s.Title,
                   Director = s.Director,
                   ReleaseYear = s.ReleaseYear,
                   Price = s.Price,
                   ImageURL = s.ImageURL
               }).ToList();


            frontPage.PopularMovieList = popularMovies;

            var bestCustomer = _context.Orders
                .Include(o => o.OrderRows)
                .Include(o => o.Customer)
                .OrderByDescending(o => o.OrderRows.Sum(or => or.Price)).Take(1)
                .Select(s => new BestCustomerVM()
                {
                    FirstName = s.Customer.FirstName,
                    LastName = s.Customer.LastName,
                    TotalOrderCost = s.OrderRows.Sum(o => o.Price)
                }).ToList();

            frontPage.BestCustomer = bestCustomer;

            return View(frontPage);
        }
        public IActionResult OneMovieCard()
        {
            var AllMovies = _context.Movies.ToList();
            return View(AllMovies);
        }
        public IActionResult Filter(string searchString)
        {
            var AllMovies = _context.Movies.ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = AllMovies.Where(n => string.Equals(n.Title, searchString, StringComparison.CurrentCultureIgnoreCase));
                return View("OneMovieCard", filteredResultNew);
            }
            return View("OneMovieCard", AllMovies);

        }
   
        public IActionResult AddToCart(int Id)
        {
            {
                if (HttpContext.Session.Get<CartVM>(SessionKeyCart) == default)
                {
                    HttpContext.Session.Set<CartVM>(SessionKeyCart, new CartVM());
                }

                CartVM sessionObject = HttpContext.Session.Get<CartVM>(SessionKeyCart);
                var movie = _context.Movies.Find(Id);

                if (movie != null)
                {

                    var existingMovie = sessionObject.Movies.FirstOrDefault(m => m.Movieid == Id);
                    if (existingMovie != null)
                    {
                        ++existingMovie.Quantity;
                        HttpContext.Session.Set<CartVM>(SessionKeyCart, sessionObject);
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
                HttpContext.Session.Set<CartVM>(SessionKeyCart, sessionObject);
                var Count = sessionObject;
                return Json(new { Value = Count });
            }
           
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}