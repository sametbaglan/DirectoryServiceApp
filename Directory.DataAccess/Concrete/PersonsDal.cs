using Directory.DataAccess.Abstract;
using Directory.DataAccess.Concrete.EfCore;
using Directory.DataAccess.DbConnection;
using Directory.Entity.Concrete;

namespace Directory.DataAccess.Concrete
{
    public class PersonsDal: EfRepositoryDal<Persons,DataContext>,IPersonsDal
    {
    }
}
