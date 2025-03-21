using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGentle.Domain.Entities
{
    public class EmployeeEntity
    {
        public EmployeeEntity()
        {
            Name = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
        } 
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
