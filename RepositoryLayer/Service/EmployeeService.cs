using Dapper;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class EmployeeService : IEmployee
    {
        private readonly DapperContext _context;
        public EmployeeService(DapperContext context)
        {
            _context = context;
        }

        
        public async Task<IEnumerable<Employee>> GetEmployeeById(int employeeId)
        {
            var query = "SELECT * FROM Employee WHERE Id = @EmployeeId";
            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QueryAsync<Employee>(query, new { EmployeeId = employeeId });
                return employee.ToList();
            }
        }


        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var query = "SELECT * FROM Employee";
            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QueryAsync<Employee>(query);
                return employee.ToList();
            }
        }

        // update
        public async Task UpdateEmployeeBy(int empIdUpdate, string empName, int empAge, string empPosition)
        {
            var query = "UPDATE Employee SET Name = @Name, Age = @Age, Position = @Position WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", empIdUpdate, DbType.Int32);
            parameters.Add("@Name", empName, DbType.String);
            parameters.Add("@Age", empAge, DbType.Int32);
            parameters.Add("@Position", empPosition, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }


        public async Task DeleteEmployeeById(int empid)
        {
            var query = "delete from employee where id =@Empid";
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,new { EmpId = empid });
            }
        }



    }
}
