using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dES.Data.Model
{
    public class Product
    {
        public virtual int Id { get; set; }

        public virtual double Price {get;set;}

        public virtual bool Recommendation { get; set; }
        [MaxLength]
        public virtual string Description {get;set;}

        [Required]
        public virtual string Name {get;set;}

       
        public virtual HashSet<ProductOrder> ProductOrders { get; set; }
        public virtual HashSet<ProductReview> Reviews { get; set; }
        public virtual int LaptopId { get; set; }
        public virtual Laptop Laptop { get; set; }

        [NotMapped]
        public string Title => $"{Laptop?.Brand?.Name} {Name} {Laptop?.Processor?.Name} {Laptop?.Processor?.Frequency}";

    }
}
