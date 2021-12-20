using System.ComponentModel.DataAnnotations;

namespace dES.Data.Model
{
    public class OrderPayment
    {
        virtual public int Id { get; set; }
        [Display(Name = "Suma")]
        virtual public double Ammount { get; set; }
        [Display(Name = "Mokėjimo metodas")]
        virtual public PaymentMethod Method { get; set; }

        [Display(Name = "Užsakymo ID")]
        virtual public int OrderId { get; set; }
        virtual public Order Order { get; set; }

        public enum PaymentMethod
        {
            Cash,
            BankTrasnfer,
            Card
        }
    }
}
