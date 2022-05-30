using Directory.Entity.Abstract;
using System.Collections.Generic;

namespace Directory.Entity.Concrete
{
    public class InfoType:BaseEntity
    {
        public int id { get; set; }
        public string type { get; set; }
        public List<ContactInformation>  contactInformations{ get; set; }
    }
}
