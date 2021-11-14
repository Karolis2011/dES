using System.ComponentModel.DataAnnotations;

namespace dES.Data.Model
{
    public class RAM
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual string MemoryCapacity { get; set; }
        [Required]
        public virtual string Frequency { get; set; }
        [Required]
        public virtual string Name { get; set; }
        public virtual int LaptopId { get; set; }
        public virtual Laptop Laptop { get; set; }
    }
}
