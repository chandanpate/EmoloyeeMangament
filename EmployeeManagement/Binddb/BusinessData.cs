using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Binddb
{
    public class BusinessData:DbContext
    {
        public BusinessData(DbContextOptions<BusinessData>options):base(options)
        {
               
        }
        public DbSet<Empdata> Empdata { get; set; }
        public DbSet<LoginModel> loginmodels { get; set; }
    }
}
