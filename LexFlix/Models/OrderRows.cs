using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LexFlix.Models
{
    public class OrderRows
    {

        public int Id { get; set; }

        public virtual Orders Order { get; set; }

        public int OrderId { get; set; }

        public virtual Movies Movie { get; set; }

        public int MovieId  { get; set; }

        public decimal Price { get; set; }

        public OrderRows()
        {

        }

        public OrderRows(int id, int orderId, int movieId, decimal price)
        {
            Id = id;
            OrderId = orderId;
            MovieId = movieId;
            Price = price;
        }   
    }
}
