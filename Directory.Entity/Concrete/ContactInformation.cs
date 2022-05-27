using Directory.Entity.Abstract;

namespace Directory.Entity.Concrete
{
    public class ContactInformation:BaseEntity
    {
        public int id { get; set; }
        public string InfoType { get; set; }
        public string InfoContent { get; set; }
        public int personid { get; set; }
        public Persons persons { get; set; }
    }
}
