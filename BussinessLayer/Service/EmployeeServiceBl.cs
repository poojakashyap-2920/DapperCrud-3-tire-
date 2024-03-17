using BussinessLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Service
{
    public class EmployeeServiceBl : IEmployeeBl
    {
        private readonly IEmployee employee;

        public EmployeeServiceBl(IEmployee employee)
        {
            this.employee = employee;
        }

        public Task<IEnumerable<Employee>> GetEmployeeById(int employeeId)
        {
            return employee.GetEmployeeById(employeeId);
        }

        public Task<IEnumerable<Employee>> GetEmployees()
        {
            return employee.GetEmployees();
        }
        // delete

        public Task DeleteEmployeeById(int empid)
        {
            return employee.DeleteEmployeeById(empid);
        }

        /*public Task<IEnumerable<Employee>> GetEmployees(int id)
        {
            return employee.GetEmployees();
        }*/

        public Task UpdateEmployeeBy(int empIdUpdate, string empName, int empAge, string empPosition)

        {
           return employee.UpdateEmployeeBy(empIdUpdate, empName, empAge, empPosition);
        }


    }
}
