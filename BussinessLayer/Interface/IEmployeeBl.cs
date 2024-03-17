using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interface
{
   public interface IEmployeeBl
    {
        public Task<IEnumerable<Employee>> GetEmployees();

        public Task<IEnumerable<Employee>> GetEmployeeById(int employeeId);
        public Task DeleteEmployeeById(int empid);
        public Task UpdateEmployeeBy(int empIdUpdate, string empName, int empAge, string empPosition);

    }
}
