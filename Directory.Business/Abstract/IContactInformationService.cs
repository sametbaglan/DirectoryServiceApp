using Directory.Entity.Concrete;
using System.Collections.Generic;

namespace Directory.Business.Abstract
{
    public interface IContactInformationService
    {
        ContactInformation GetPersonContactid(int id);
        List<ContactInformation> GetAll();
        ContactInformation GetById(int id);
        void Create(ContactInformation entity);
        void Update(ContactInformation entity);
    }
}
