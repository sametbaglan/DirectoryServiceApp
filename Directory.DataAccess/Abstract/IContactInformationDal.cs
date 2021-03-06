using Directory.Core.RepositoryDesign.Abstract;
using Directory.Entity.Concrete;

namespace Directory.DataAccess.Abstract
{
    public interface IContactInformationDal : IRepository<ContactInformation>
    {
        ContactInformation GetPersonContactid(int id);
    }
}
