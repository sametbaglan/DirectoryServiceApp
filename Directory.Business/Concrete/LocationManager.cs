using Directory.Business.Abstract;
using Directory.DataAccess.Abstract;
using Directory.Entity.Concrete;
using System.Collections.Generic;

namespace Directory.Business.Concrete
{
    public class LocationManager : ILocationService
    {
        private readonly ILocationDal _locationDal;
        public LocationManager(ILocationDal locationDal)
        {
            _locationDal = locationDal;
        }
        public void Create(Location entity)
        {
            _locationDal.Create(entity);
        }

        public List<Location> GetAll()
        {
            return _locationDal.GetAll();
        }

        public Location GetById(int id)
        {
            return _locationDal.GetById(id);
        }

        public List<Location> GetLocationsByContactid(int contactid)
        {
            return _locationDal.GetLocationsByContactid(contactid);
        }

        public void Update(Location entity)
        {
            _locationDal.Update(entity);
        }
    }
}
