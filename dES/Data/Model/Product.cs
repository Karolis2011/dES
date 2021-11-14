using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dES.Data.Model
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual double Price {get;set;}
        [MaxLength]
        public virtual string Description {get;set;}
        [MaxLength(60)]
        [Required]
        public virtual string Name {get;set;}
        public virtual HashSet<ProductOrder> ProductOrders { get; set; }
        public virtual HashSet<ProductReview> Reviews { get; set; }
        public virtual HashSet<Laptop> Laptops { get; set; }

    }
}
