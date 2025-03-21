using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGentle.Domain.Entities;
using WebGentle.Domain.Interfaces;
using WebGentle.Infrastructure.Data;

namespace WebGentle.Infrastructure.Repositories
{
    public class EmployeeRepository(AppDbContext context) : IEmployeeRepository
    {
        public async Task<List<EmployeeEntity>> GetEmployees()
        {
            return await context.Employees.ToListAsync();
        }

        public async Task<EmployeeEntity> GetEmployeeByIdAsync(Guid id)
        {
            return await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EmployeeEntity> AddEmployee(EmployeeEntity employee)
        {
            employee.Id = Guid.NewGuid();
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
            return employee;
        }
        public async Task<EmployeeEntity> UpdateEmployee(Guid id, EmployeeEntity employee)
        {
            var emp = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (emp is not null)
            {
                emp.Name = employee.Name;
                emp.Email = employee.Email;
                emp.Phone = employee.Phone;
                context.Employees.Update(emp);
                await context.SaveChangesAsync();
                return emp;
            }
            return employee;
        }

        public async Task<bool> DeleteEmployee(Guid id)
        {
            var emp = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (emp is not null)
            {
                context.Employees.Remove(emp);
                return await context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
