using System.ComponentModel.DataAnnotations;

namespace dES.Data.Model
{
    public class OperatingSystem
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual string Name { get; set; }
    }
}
