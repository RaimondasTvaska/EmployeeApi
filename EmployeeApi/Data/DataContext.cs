using EmployeeApi.Entyties;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(ce => ce.Employees)
                .WithOne()
                .HasForeignKey(c => c.CompanyListId);
        }
    }
}
