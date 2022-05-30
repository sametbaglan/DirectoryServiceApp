using Directory.Business.Abstract;
using Directory.DataAccess.Abstract;
using Directory.Entity.Concrete;
using System.Collections.Generic;

namespace Directory.Business.Concrete
{
    public class InfoTypeManager : IInfoTypeService
    {
        private readonly IInfoTypeDal _ınfoTypeDal;
        public InfoTypeManager(IInfoTypeDal ınfoTypeDal)
        {
            _ınfoTypeDal= ınfoTypeDal;
        }
        public void Create(InfoType entity)
        {
            _ınfoTypeDal.Create(entity);
        }

        public List<InfoType> GetAll()
        {
            return _ınfoTypeDal.GetAll(x=>x.Delete==false);
        }

        public InfoType GetById(int id)
        {
            return _ınfoTypeDal.GetById(id);
        }

        public void Update(InfoType entity)
        {
            _ınfoTypeDal.Update(entity);
        }
    }
}
