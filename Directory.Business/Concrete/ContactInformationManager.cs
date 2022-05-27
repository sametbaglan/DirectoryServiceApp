using Directory.Business.Abstract;
using Directory.DataAccess.Abstract;
using Directory.Entity.Concrete;
using System.Collections.Generic;

namespace Directory.Business.Concrete
{
    public class ContactInformationManager : IContactInformationService
    {
        private readonly IContactInformationDal _contactInformationDal;
        public ContactInformationManager(IContactInformationDal contactInformationDal)
        {
            _contactInformationDal = contactInformationDal;
        }
        public void Create(ContactInformation entity)
        {
            _contactInformationDal.Create(entity);
        }

        public List<ContactInformation> GetAll()
        {
            return _contactInformationDal.GetAll();
        }

        public ContactInformation GetById(int id)
        {
            return _contactInformationDal.GetById(id);
        }

        public void Update(ContactInformation entity)
        {
            _contactInformationDal.Update(entity);
        }
    }
}
