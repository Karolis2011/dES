using System.ComponentModel.DataAnnotations;

namespace dES.Data.Model
{
    public class ActionInformation
    {
        public virtual long Id { get; set; }
        public virtual int Type { get; set; }
        public virtual int SubType { get; set; }
        [MaxLength(128)]
        public virtual string Data { get; set; }

    }
}
