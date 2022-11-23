using LexFlix.Data;
using LexFlix.Exceptions;
using LexFlix.Helper;
using LexFlix.Models.ViewModels;
using LexFlix.Services;
using Microsoft.AspNetCore.Mvc;

namespace LexFlix.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MoviesController> _logger;
        private readonly IMovieServices _movieServices;
        private readonly ICartServices _cartServices;

        const string SessionKeyUsername = "SessionKeyUsername";
        const string SessionKeyCart = "ShoppingCart";

        public CartController(ApplicationDbContext context, ILogger<MoviesController> logger,
            IMovieServices movieServices,ICartServices cartServices)
        {
            _context = context;
            _logger = logger;
            _movieServices = movieServices;
            _cartServices = cartServices; 
        }
        public IActionResult RemoveFromCart(int id)
        {
            _cartServices.RemoveSessionFromCart(id);

            return RedirectToAction("ShowCart");
        }

        public IActionResult IncrementfromCart(int Id)
        {
            _cartServices.IncrementSessionFromCart(Id);
            return RedirectToAction("ShowCart");
        }

        public IActionResult DecrementfromCart(int Id)
        {
            try
            {
                _cartServices.DecrementSessionFromCart(Id);
            }
            catch (EmptyCartException)
            {
                return RedirectToAction("RemoveFromCart", new { id = Id });
            }
            return RedirectToAction("ShowCart");
        }
        public async Task<IActionResult> ShowCart()
        {

            CartVM sessionObject = HttpContext.Session.Get<CartVM>(SessionKeyCart);

            return View(sessionObject);
        }
    }
}
