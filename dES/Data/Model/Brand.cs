using System.ComponentModel.DataAnnotations;

namespace dES.Data.Model
{
    public class Brand
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual string Name { get; set; }
    }
}
