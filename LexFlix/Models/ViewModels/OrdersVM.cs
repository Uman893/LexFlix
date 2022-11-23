using LexFlix.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
namespace LexFlix.Models.ViewModels
{
    public class OrdersVM
    {        
        public decimal Price { get; set; }
        public int OrderId { get; set; }        
        public string Title { get; set; }
        public string Email { get; set; }
        public string Director { get; set; }
        public OrdersVM()
        {
            
        }
        public OrdersVM( decimal price, int orderid, string title, string email, string director)
        {                                   
            Price = price;
            OrderId = orderid;
            Title = title;
            Email = email;
            Director = director;
        }
    }
}
