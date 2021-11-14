using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dES.Data.Model
{
    public class Laptop
    {
        public virtual int Id { get; set; }
        [MaxLength(64)]
        public virtual string Name {get;set;}
        [Required]
        public virtual int OSId {get;set;}
        public virtual OperatingSystem OS { get;set;}
        [Required]
        public virtual int BrandId {get; set;}
        public virtual Brand Brand {get;set;}
        [Required]
        public virtual int ProccessorId {get;set;}
        public virtual Processor Proccesor {get;set;}
        [Required]
        public virtual HashSet<RAM> RAMs {get;set;}
        [Required] 
        public virtual int ProductId { get; set; }
        public virtual Product Product {get;set;}
    }
}
