using Directory.Entity.Concrete;
using System.Collections.Generic;

namespace Directory.Business.Abstract
{
    public interface ILocationService
    {

        List<Location> GetLocationsByContactid(int contactid);
        List<Location> GetAll();
        Location GetById(int id);
        void Create(Location entity);
        void Update(Location entity);
    }
}
