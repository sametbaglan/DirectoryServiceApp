using Directory.Core.RepositoryDesign.Abstract;
using Directory.Entity.Concrete;
using System.Collections.Generic;

namespace Directory.DataAccess.Abstract
{
    public interface ILocationDal:IRepository<Location>
    {
        List<Location> GetLocationsByContactid(int contactid);

    }
}
