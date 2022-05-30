using Directory.Entity.Abstract;
using System.Collections.Generic;

namespace Directory.Entity.Concrete
{
    public class ContactInformation : BaseEntity
    {
        public int id { get; set; }
        public int infotypeid { get; set; }
        public InfoType InfoType { get; set; }
        public string InfoContent { get; set; }
        public List<Location>  Locations{ get; set; }
        public int personid { get; set; }
        public Persons persons { get; set; }
    }
}
