using Directory.Entity.Concrete;
using System.Collections.Generic;

namespace Directory.Business.Abstract
{
    public interface IPersonService
    {
        List<Persons> GetAll();
        Persons GetById(int id);
        void Create(Persons entity);
        void Update(Persons entity);
    }
}
