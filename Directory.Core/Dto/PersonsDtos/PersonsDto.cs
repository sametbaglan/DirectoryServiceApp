using Directory.Entity.Concrete;
using System.Collections.Generic;

namespace Directory.Core.Dto.PersonsDtos
{
    public class PersonsDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public List<ContactInformation> contactInformations { get; set; }
    }
}
