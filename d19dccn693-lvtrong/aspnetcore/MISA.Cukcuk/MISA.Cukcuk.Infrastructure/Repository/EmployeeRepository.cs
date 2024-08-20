using Dapper;
using MISA.Cukcuk.Core.Entities;
using MISA.Cukcuk.Core.Interfaces.Infrastructure;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace MISA.Cukcuk.Infrastructure.Repository
{
    public class EmployeeRepository :IEmployeeRepository
    {
        private const string _connectionString = "Server=127.0.0.1; Port=3306; Database=dsnv; User=root; Password=admin;";
        private MySqlConnection _mySqlConnection;
        public EmployeeRepository()
        {
            _mySqlConnection = new MySqlConnection(_connectionString);
        }

        public IEnumerable<Employee> GetAll()
        {
            var className = typeof(Employee).Name;
            using (_mySqlConnection = new MySqlConnection(_connectionString))
            {
                var sqlCommand = $"SELECT * FROM {className}";
                var employee = _mySqlConnection.Query<Employee>(sqlCommand);

                return employee;
            }
        }

       
        public Employee GetById(Guid id)
        {
            var className = typeof(Employee).Name;
            using (_mySqlConnection = new MySqlConnection(_connectionString))
            {
                var sqlCommand = $"SELECT * FROM {className} WHERE {className}Id = @{className}Id";
                DynamicParameters dynaParam = new DynamicParameters();
                dynaParam.Add($"@{className}Id", id);
                var employee = _mySqlConnection.QueryFirstOrDefault<Employee>(sqlCommand, param: dynaParam);

                return employee;
            }
        }

        public int Delete(Guid employeeId)
        {
            var className = typeof(Employee).Name;
            using (_mySqlConnection = new MySqlConnection(_connectionString))
            {
                var sqlCommand = $"DELETE FROM {className} WHERE {className}Id = @{className}Id";
                DynamicParameters dynaParam = new DynamicParameters();
                dynaParam.Add($"@{className}Id", employeeId);
                var res = _mySqlConnection.Execute(sqlCommand, param: dynaParam);

                return res;
            }
        }

        public IEnumerable<Employee> GetPaging(int pageSize, int pageNumber)
        {
            var sqlCommand = $"SELECT * FROM employee LIMIT {pageSize} offset {pageNumber}";
            using (_mySqlConnection = new MySqlConnection(_connectionString))
            {
                var employees = _mySqlConnection.Query<Employee>(sql: sqlCommand);
                return employees;
            }
        }

        public int Insert(Employee employee)
        {
            employee.EmployeeId = Guid.NewGuid();

            // Establish connection to database
            var mySqlConnection = new MySqlConnection(_connectionString);

            // Add data to database
            var sqlCommandText = "Proc_InsertEmployee";

            // Open Connection
            mySqlConnection.Open();

            // Parameters

            var sqlCommand = mySqlConnection.CreateCommand();
            sqlCommand.CommandText = sqlCommandText;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            MySqlCommandBuilder.DeriveParameters(sqlCommand);

            var dynaParam = new DynamicParameters();
            foreach (MySqlParameter parameter in sqlCommand.Parameters)
            {
                // parameter name
                var paramName = parameter.ParameterName;
                var propName = paramName.Replace("@p", "");
                var entityProperty = employee.GetType().GetProperty(propName);
                if (entityProperty != null)
                {
                    var propValue = employee.GetType().GetProperty(propName).GetValue(employee);
                    // add value to param
                    dynaParam.Add(paramName, propValue);
                }
                else
                {
                    dynaParam.Add(paramName, null);
                }
            }

            var res = mySqlConnection.Execute(sql: sqlCommandText, param: dynaParam, commandType: System.Data.CommandType.StoredProcedure);

            return res;
        }

        public int Update(Employee employee, Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public bool IsDuplicateCode(string employeeCode)
        {
            var mySqlConnection = new MySqlConnection(_connectionString);
            var sqlCheck = "SELECT EmployeeCode FROM employee WHERE EmployeeCode = @EmployeeCode";
            var dynaParam = new DynamicParameters();
            dynaParam.Add("@EmployeeCode", employeeCode);
            var res = mySqlConnection.QueryFirstOrDefault<string>(sqlCheck, param: dynaParam);
            return res != null ? true : false;
        }

    }
}
