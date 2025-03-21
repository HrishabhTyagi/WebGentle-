using WebGentle.Domain.Entities;

namespace WebGentle.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<List<EmployeeEntity>> GetEmployees();
        public Task<EmployeeEntity> GetEmployeeByIdAsync(Guid id);
        public Task<EmployeeEntity> AddEmployee(EmployeeEntity employee);
        public Task<EmployeeEntity> UpdateEmployee(Guid id, EmployeeEntity employee);
        public Task<bool> DeleteEmployee(Guid id);
    }
}