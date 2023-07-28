using Microsoft.EntityFrameworkCore;
using static UspacyToPerfectum.Program;

namespace TestApi.Data
{
    public class DataDB : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DataDB(DbContextOptions<DataDB> options) :base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
