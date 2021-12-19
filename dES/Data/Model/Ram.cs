using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace dES.Data.Model
{
    public class RAM
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual string MemoryCapacity { get; set; }

        [Required]
        public virtual string Frequency { get; set; }


        public virtual HashSet<Laptop> Laptops { get; set; }


    }
}
