namespace dES.Data.Model
{
    public class OrderPayment
    {
        virtual public int Id { get; set; }
        virtual public double Ammount { get; set; }
        virtual public PaymentMethod Method { get; set; }

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
