using MediatR;
using WebGentle.Domain.Entities;
using WebGentle.Domain.Interfaces;

namespace WebGentle.Application.Commands
{
    public record AddEmployeeCommand(EmployeeEntity  employee) : IRequest<EmployeeEntity>;

    public class AddEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<AddEmployeeCommand, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.AddEmployee(request.employee);
        }
    }
}