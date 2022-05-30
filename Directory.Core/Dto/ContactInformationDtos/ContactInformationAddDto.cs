using Directory.Entity.Concrete;

namespace Directory.Core.Dto.ContactInformationDtos
{
    public class ContactInformationAddDto
    {
        public int id { get; set; }
        public int infotypeid { get; set; }
        public string InfoContent { get; set; }
        public int personid { get; set; }
    }
}
