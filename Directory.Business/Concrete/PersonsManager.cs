using Directory.Business.Abstract;
using Directory.DataAccess.Abstract;
using Directory.Entity.Concrete;
using System.Collections.Generic;

namespace Directory.Business.Concrete
{
    public class PersonsManager : IPersonService
    {
        private readonly IPersonsDal _personsDal;
        public PersonsManager(IPersonsDal personsDal)
        {
            _personsDal = personsDal;
        }
        public void Create(Persons entity)
        {
            _personsDal.Create(entity);
        }

        public List<Persons> GetAll()
        {
            return _personsDal.GetAll();
        }

        public Persons GetById(int id)
        {
            return _personsDal.GetById(id);
        }

        public void Update(Persons entity)
        {
            _personsDal.Update(entity);
        }
    }
}
