using System;
using System.ComponentModel.DataAnnotations;

namespace dES.Data.Model
{
    public class ProductReview
    {
        public virtual int Id { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual byte Rating { get; set; }
        [MaxLength]
        public virtual string Review { get; set; }

        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public virtual string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
