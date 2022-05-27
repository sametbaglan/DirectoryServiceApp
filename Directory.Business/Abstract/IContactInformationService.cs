using Directory.Entity.Concrete;
using System.Collections.Generic;

namespace Directory.Business.Abstract
{
    public interface IContactInformationService
    {
        List<ContactInformation> GetAll();
        ContactInformation GetById(int id);
        void Create(ContactInformation entity);
        void Update(ContactInformation entity);
    }
}
