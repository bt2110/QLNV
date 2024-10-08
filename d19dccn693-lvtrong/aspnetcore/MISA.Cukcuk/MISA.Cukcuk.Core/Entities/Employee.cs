﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Cukcuk.Core.Entities
{
    public class Employee
    {
        #region Constructor
        public Employee()
        {

        }
        #endregion

        #region Property
        /// <summary>
        /// Primary Key
        /// </summary>
        public Guid EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime? IdentityDate { get; set; }
        public string? IdentityPlace { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? PersonalTaxCode { get; set; }
        public int? Salary { get; set; }
        public DateTime? JoinDate { get; set; }
        public int? WorkStatus { get; set; }
        public Guid? PositionId { get; set; }
        public string? PositionCode { get; set; }
        public string? PositionName { get; set; }
        public Guid? DepartmentId { get; set; }
        public string? DepartmentCode { get; set; }
        public string? DepartmentName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        #endregion
    }
}

