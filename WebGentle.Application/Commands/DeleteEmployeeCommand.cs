using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGentle.Domain.Interfaces;

namespace WebGentle.Application.Commands
{
    public record DeleteEmployeeCommand(Guid id) : IRequest<bool>;

    public class DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
           return await employeeRepository.DeleteEmployee(request.id);
        }
    }
}
