using Microsoft.EntityFrameworkCore;
using WebGentle.Domain.Entities;

namespace WebGentle.Infrastructure.Data
{
    public  class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<EmployeeEntity> Employees { get; set; }
    }
}
