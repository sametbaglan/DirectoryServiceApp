using Directory.Core.Exceptions;
using Directory.DataAccess.Abstract;
using Directory.DataAccess.Concrete.EfCore;
using Directory.DataAccess.DbConnection;
using Directory.Entity.Concrete;
using System.Linq;

namespace Directory.DataAccess.Concrete
{
    public class ContactInformationDal : EfRepositoryDal<ContactInformation, DataContext>, IContactInformationDal
    {
        public ContactInformation GetPersonContactid(int id)
        {
            using (var db=new DataContext())
            {
                var entity = db.Set<ContactInformation>().Where(x => x.personid == id).FirstOrDefault();
                if (entity == null)
                {
                    throw new SuccessException("Not Found");
                }
                return entity;
            }
        }
    }
}
