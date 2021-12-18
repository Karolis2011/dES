using System.ComponentModel.DataAnnotations;

namespace dES.Data.Model
{
    public class Processor
    {
        public virtual int Id { get; set; }

        [MaxLength(64)]
        [Required]  
        public virtual string Name { get; set; }    
        public virtual string Frequency{ get; set; }  

        [Required]  
        public virtual int Cores { get; set; }    

 

    }
}
