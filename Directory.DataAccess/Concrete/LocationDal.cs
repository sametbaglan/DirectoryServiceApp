using Directory.DataAccess.Abstract;
using Directory.DataAccess.Concrete.EfCore;
using Directory.DataAccess.DbConnection;
using Directory.Entity.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Directory.DataAccess.Concrete
{
    public class LocationDal : EfRepositoryDal<Location, DataContext>, ILocationDal
    {
        public List<Location> GetLocationsByContactid(int contactid)
        {
            using (var db=new DataContext())
            {
                return db.Set<Location>().Where(x => x.contactinformationid == contactid).ToList();
            }
        }
    }
}
