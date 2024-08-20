using MISA.Cukcuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Cukcuk.Core.Interfaces.Infrastructure
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(Guid employeeId);

        int Insert(Employee employee);
        int Update(Employee employee, Guid employeeId);
        int Delete(Guid employeeId);
        IEnumerable<Employee> GetPaging(int pageSize, int pageNumber);
        bool IsDuplicateCode(string employeeCode);
    }
}
