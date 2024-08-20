using MISA.Cukcuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Cukcuk.Core.Interfaces.Services
{
    public interface  IEmployeeService
    {
        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// Created by LVTrong
        int InsertService(Employee employee);

        /// <summary>
        /// Edit Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// Created by LVTrong
        int UpdateService(Employee employee, Guid employeeId);
    }
}
