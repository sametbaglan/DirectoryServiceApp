using Directory.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Directory.DataAccess.DbConnection
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Database=DirectoryDb;User ID=postgres;Password=1425369As;Port=5432;Integrated Security=true;Pooling=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactInformation>()
                .HasOne(X => X.persons)
                .WithMany(x => x.contactInformations)
                .HasForeignKey(x => x.personid);
        }
    }
}
