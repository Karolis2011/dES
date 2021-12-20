using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dES.Data.Model
{
    public class Laptop
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual int OSId { get; set; }
        public virtual OperatingSystem OS { get; set; }

        [Required]
        public virtual int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        [Required]
        public virtual int ProcessorId { get; set; }
        public virtual Processor Processor { get; set; }

        [Required]
        public virtual int RAMId { get; set; }

        public virtual RAM RAM { get; set; }

        public virtual Product Product { get; set; }


    }
}
