using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dES.Data.Model
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual OrderState State { get; set;}

        [Required]
        public virtual string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual HashSet<ProductOrder> ProductOrders { get; set; }
        public virtual HashSet<OrderPayment> Payments { get; set; }

        public enum OrderState
        {
            Received,
            Sent,
            Paid
        }
    }
}
