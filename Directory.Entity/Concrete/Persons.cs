using Directory.Entity.Abstract;
using System.Collections.Generic;

namespace Directory.Entity.Concrete
{
    public class Persons:BaseEntity
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public List<ContactInformation> contactInformations{ get; set; }
    }
}
