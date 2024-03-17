using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
   public interface IEmployee
    {
        public Task<IEnumerable<Employee>> GetEmployees();
        //update
        public Task UpdateEmployeeBy(int empIdUpdate, string empName, int empAge, string empPosition);

        public Task<IEnumerable<Employee>> GetEmployeeById(int employeeId);

             //delete
             public Task DeleteEmployeeById(int empid);
    }

    
}
 