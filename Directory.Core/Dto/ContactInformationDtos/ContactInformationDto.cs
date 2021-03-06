using Directory.Entity.Concrete;

namespace Directory.Core.Dto.ContactInformationDtos
{
    public class ContactInformationDto
    {
        public int id { get; set; }
        public int infotypeid { get; set; }
        public InfoType InfoType { get; set; }
        public string InfoContent { get; set; }
        public int personid { get; set; }
        public Persons persons { get; set; }
    }
}
