using System;

namespace Directory.Entity.Abstract
{
    public abstract class BaseEntity
    {
        public DateTime CreateDate{ get; set; }
        public DateTime ModifyDate { get; set; }
        public bool Delete { get; set; }
    }
}
