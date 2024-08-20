using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Cukcuk.Core.Entities;
using MISA.Cukcuk.Core.Execptions;
using MISA.Cukcuk.Core.Interfaces.Infrastructure;
using MISA.Cukcuk.Core.Interfaces.Services;
using MISA.Cukcuk.Infrastructure.Repository;
using MySqlConnector;

namespace MISA.Cukcuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeRepository employeeRepository, IEmployeeService employeeService)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
        }



        /// <summary>
        /// Lấy danh sách toàn bộ nhân viên.
        /// </summary>
        /// <returns>Danh sách nhân viên.</returns>
        /// <response code="200">Trả về danh sách nhân viên.</response>
        /// <response code="400">Lỗi trong quá trình xử lý.</response>
        /// Created by LVTrong
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var employees = _employeeRepository.GetAll();
                return Ok(employees);
            }
            catch (CustomException ex)
            {
                // Return a meaningful error response
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = "An error occurred while fetching employees.",
                    data = ex.Data
                };
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Lấy thông tin nhân viên theo ID.
        /// </summary>
        /// <param name="id">ID của nhân viên.</param>
        /// <returns>Thông tin nhân viên.</returns>
        /// <response code="200">Trả về thông tin nhân viên.</response>
        /// <response code="404">Không tìm thấy nhân viên.</response>
        /// <response code="400">Lỗi trong quá trình xử lý.</response>
        /// Created by LVTrong

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var employee = _employeeRepository.GetById(id);
                if (employee == null)
                {
                    return NotFound("Employee not found.");
                }
                return Ok(employee);
            }
            catch (CustomException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = "An error occurred while fetching employee details.",
                    data = ex.Data
                };
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Thêm mới một nhân viên.
        /// </summary>
        /// <param name="employee">Thông tin nhân viên cần thêm.</param>
        /// <returns>Thông báo thành công hoặc lỗi.</returns>
        /// <response code="201">Nhân viên được thêm thành công.</response>
        /// <response code="400">Lỗi trong quá trình xử lý.</response>
        /// Created by LVTrong
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            try
            {
                var res = _employeeService.InsertService(employee);
                return StatusCode(201, "Employee added successfully.");
            }
            catch (CustomException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = "Validation error occurred while adding the employee.",
                    data = ex.Data
                };
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Cập nhật thông tin nhân viên.
        /// </summary>
        /// <param name="id">ID của nhân viên cần cập nhật.</param>
        /// <param name="employee">Thông tin nhân viên cần cập nhật.</param>
        /// <returns>Thông báo thành công hoặc lỗi.</returns>
        /// <response code="200">Nhân viên được cập nhật thành công.</response>
        /// <response code="400">Lỗi trong quá trình xử lý.</response>
        /// Created by LVTrong
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Employee employee)
        {
            try
            {
                _employeeService.UpdateService(employee, id);
                return Ok("Employee updated successfully.");
            }
            catch (CustomException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = "An error occurred while updating the employee.",
                    data = ex.Data
                };
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Xóa một nhân viên.
        /// </summary>
        /// <param name="id">ID của nhân viên cần xóa.</param>
        /// <returns>Thông báo thành công hoặc lỗi.</returns>
        /// <response code="200">Nhân viên được xóa thành công.</response>
        /// <response code="400">Lỗi trong quá trình xử lý.</response>
        /// Created by LVTrong
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _employeeRepository.Delete(id);
                return Ok("Employee deleted successfully.");
            }
            catch (CustomException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = "An error occurred while deleting the employee.",
                    data = ex.Data
                };
                return BadRequest(response);
            }
        }
    }
}
