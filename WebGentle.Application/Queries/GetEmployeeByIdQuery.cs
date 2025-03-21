using MediatR;
using WebGentle.Domain.Entities;
using WebGentle.Domain.Interfaces;

namespace WebGentle.Application.Queries
{
    public record GetEmployeeByIdQuery(Guid employeeId) : IRequest<EmployeeEntity>;
    public class GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<GetEmployeeByIdQuery, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetEmployeeByIdAsync(request.employeeId);
        }
    }
}
