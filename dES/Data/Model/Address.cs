using System.ComponentModel.DataAnnotations;

namespace dES.Data.Model
{
    public class Address
    {
        public virtual int Id { get; set; }
        public virtual string Country { get; set; }
        public virtual string City { get; set; }
        public virtual string Street { get; set; }
        [MaxLength(32)]
        public virtual string ResidenceNumber { get; set; }


        [Required]
        public virtual string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
