namespace Directory.Entity.Concrete
{
    public class Location
    {
        public int id { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string zipcode { get; set; }
        public string County { get; set; }
        public string street { get; set; }
        public int contactinformationid { get; set; }
        public ContactInformation contact { get; set; }

    }
}
