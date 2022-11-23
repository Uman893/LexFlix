using LexFlix.Models.ViewModels;

namespace LexFlix.Models
{

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BillingAddress { get; set; }
        public string BillingZip { get; set; }
        public string BillingCity { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryZip { get; set; }
        public string DeliveryCity { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }

        public Customer()
        {

        }

        public Customer(int id, string firstName, string lastName, string billingAddress, string billingZip, string billingCity, string deliveryAddress, string deliveryZip, string deliveryCity, string email, string phoneNo)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BillingAddress = billingAddress;
            BillingZip = billingZip;
            BillingCity = billingCity;
            DeliveryAddress = deliveryAddress;
            DeliveryZip = deliveryZip;
            DeliveryCity = deliveryCity;
            Email = email;
            PhoneNo = phoneNo;
        }
    }
}
