namespace dES.Data.Model
{
    public class ProductOrder
    {
        virtual public int ProductId { get; set; }
        virtual public Product Product { get; set; }

        virtual public int OrderId { get; set; }
        virtual public Order Order { get; set; }
    }
}
