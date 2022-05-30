using Directory.Entity.Concrete;
using System.Collections.Generic;

namespace Directory.Business.Abstract
{
    public interface IInfoTypeService
    {
        List<InfoType> GetAll();
        InfoType GetById(int id);
        void Create(InfoType entity);
        void Update(InfoType entity);
    }
}
