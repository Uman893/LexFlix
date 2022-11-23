using System.ComponentModel.DataAnnotations;

namespace LexFlix.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public virtual Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public virtual List<OrderRows> OrderRows { get; set; }
        
        public Orders()
        {

        }

        public Orders(int id, DateTime orderDate, int customerId)
        {
            Id = id;
            OrderDate = orderDate;
            CustomerId = customerId;
        }   
    }
}
