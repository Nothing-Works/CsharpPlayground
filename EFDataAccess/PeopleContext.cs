using Microsoft.EntityFrameworkCore;

namespace EFDataAccess
{
    public class PeopleContext : DbContext
    {
        public DbSet<People> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> Emails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFDataAccess;Integrated Security=true;");
        }
    }
}