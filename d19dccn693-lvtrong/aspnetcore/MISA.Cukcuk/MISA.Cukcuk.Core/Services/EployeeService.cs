using MISA.Cukcuk.Core.Entities;
using MISA.Cukcuk.Core.Execptions;
using MISA.Cukcuk.Core.Interfaces.Infrastructure;
using MISA.Cukcuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Cukcuk.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public int InsertService(Employee employee)
        {

            // Validate Data(Return 400(BadRequest) and information of error
            // Data cannot null
            // Check null
            if (string.IsNullOrEmpty(employee.EmployeeCode))
            {
                throw new CustomException(Resource.ResourceVN.ErrorCode_Required);
            }

            if (string.IsNullOrEmpty(employee.FullName))
            {
                throw new CustomException(Resource.ResourceVN.EmployeeNameRequired);
            }

            if (string.IsNullOrEmpty(employee.Email))
            {
                throw new CustomException(Resource.ResourceVN.EmailRequired);
            }

            if (string.IsNullOrEmpty(employee.IdentityNumber))
            {
                throw new CustomException(Resource.ResourceVN.IdentityRequired);
            }

            // Check formation email
            if (!IsValidEmail(email: employee.Email))
            {
                throw new CustomException(Resource.ResourceVN.InvalidEmailFormat);
            }

            // Check duplicate code
            bool isDupe = _employeeRepository.IsDuplicateCode(employee.EmployeeCode);
            if (isDupe)
            {
                throw new CustomException(Resource.ResourceVN.EmployeeDuplicate);
            }
            var res = _employeeRepository.Insert(employee);
            return res;
        }

        public int UpdateService(Employee employee, Guid employeeId)
        {
            if (string.IsNullOrEmpty(employee.EmployeeCode))
            {
                throw new CustomException(Resource.ResourceVN.ErrorCode_Required);
            }

            if (string.IsNullOrEmpty(employee.FullName))
            {
                throw new CustomException(Resource.ResourceVN.EmployeeNameRequired);
            }

            if (string.IsNullOrEmpty(employee.Email))
            {
                throw new CustomException(Resource.ResourceVN.EmailRequired);
            }

            if (string.IsNullOrEmpty(employee.IdentityNumber))
            {
                throw new CustomException(Resource.ResourceVN.IdentityRequired);
            }

            // Check formation email
            if (!IsValidEmail(email: employee.Email))
            {
                throw new CustomException(Resource.ResourceVN.InvalidEmailFormat);
            }

            // Check EmployeeNotFound
            bool isDupe = _employeeRepository.IsDuplicateCode(employee.EmployeeCode);
            if (!isDupe)
            {
                throw new CustomException(Resource.ResourceVN.EmployeeNotFound);
            }
            var res = _employeeRepository.Update(employee,employeeId);
            return res;
        }


        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
