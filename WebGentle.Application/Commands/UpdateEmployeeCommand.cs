using MediatR;
using WebGentle.Domain.Entities;
using WebGentle.Domain.Interfaces;

namespace WebGentle.Application.Commands
{

    public record UpdateEmployeeCommand(Guid id, EmployeeEntity employee) : IRequest<EmployeeEntity>;

    public class UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<UpdateEmployeeCommand, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken) {
            return await employeeRepository.UpdateEmployee(request.id, request.employee);
        }
    }
}
