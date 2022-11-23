using LexFlix.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using LexFlix.Data;
using Humanizer;
using LexFlix.Models;
using System.Reflection.Metadata.Ecma335;
using System.Linq;
using System.Reflection;

namespace LexFlix.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;
        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult ShowOrder()
        {

            return View();
        }
        public IActionResult FindOrder(string email)
        {
            var customer = _db.Customers.FirstOrDefault(c => c.Email == email);
            // You will need to check that this was an actual email in the system befor starting to acces db

            if (customer == null)
            {
                return RedirectToAction("NoOrdersFound");
            }
            else
            {
                var purchaseSummary = _db.Orders.Where(o => o.CustomerId == customer.Id).Join(_db.OrderRows,
                    o => o.Id,
                    or => or.OrderId,
                    (o, or) => new { o, or }).Join(_db.Movies,
                    o => o.or.MovieId,
                    m => m.Id,
                    (o, m) => new OrdersVM
                    {
                        Title = m.Title,
                        Price = o.or.Price,
                        OrderId = o.or.OrderId,
                        Email = customer.Email,
                        Director = m.Director,

                    }).ToList();

                return View(purchaseSummary);
            }

        }

        public IActionResult NoOrdersFound()
        {
            return View();
        }
    }
}
