using LexFlix.Data;
using LexFlix.Models.ViewModels;
using LexFlix.Models;
using LexFlix.Helper;
using LexFlix.Exceptions;

namespace LexFlix.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CartServices> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        const string SessionKeyUsername = "SessionKeyUsername";
        const string SessionKeyCart = "ShoppingCart";

        public CustomerServices(ApplicationDbContext context, ILogger<CartServices> logger, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public void ValidationSteps(string email)
        {
            var sessionobj = _httpContextAccessor.HttpContext.Session.Get<CartVM>(SessionKeyCart);

            var existingId = _context.Customers.Where(c => c.Email == email).FirstOrDefault();

            if (existingId != null)
            {
                Orders ny = new Orders
                {
                    OrderDate = DateTime.Now,
                    CustomerId = existingId.Id,
                };
                _context.Orders.Add(ny);
                _context.SaveChanges();
                Orders newrow = _context.Orders.Where(x => x.CustomerId == existingId.Id).FirstOrDefault();
                int orderId = ny.Id;
                foreach (var row in sessionobj.Movies)
                {
                    for (int i = 0; i < row.Quantity; i++)
                    {
                        _context.OrderRows.Add(
                         new OrderRows
                         {
                             OrderId = orderId,
                             MovieId = row.Movieid,
                             Price = row.Price
                         });
                    }
                }
                _context.SaveChanges();
                _httpContextAccessor.HttpContext.Session.Clear();

                throw new ValdionStepException();
            }
            else
                throw new ValidationStepExceptionView();
        }
    }
}
