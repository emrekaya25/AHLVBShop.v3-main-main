using AHLVBShop.API.Aspects;
using AHLVBShop.API.Validation.FluentValidation;
using AHLVBShop.Business.Abstract;
using AHLVBShop.Entity.DTO.EmployeeDTO;
using AHLVBShop.Entity.Poco;
using AHLVBShop.Entity.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AHLVBShop.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRoleService _roleService;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService,IMapper mapper, IRoleService roleService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _roleService = roleService;
            _departmentService = departmentService;

        }
        [HttpPost("/AddEmployee")]
        [ValidationFilter(typeof(EmployeeValidator))]
        public async Task<IActionResult> AddEmployee(EmployeeDTORequest employeeDTORequest)
        {
            Employee employee = _mapper.Map<Employee>(employeeDTORequest);
            await _employeeService.AddAsync(employee);

            EmployeeDTOResponse employeeDTOResponse = _mapper.Map<EmployeeDTOResponse>(employee);
            return Ok(Sonuc<EmployeeDTOResponse>.SuccessWithData(employeeDTOResponse));
        }

        [HttpPost("/RemoveEmployee")]
        public async Task<IActionResult> RemoveEmployee(Guid employeeId)
        {
            Employee employee = await _employeeService.GetAsync(x=>x.Id == employeeId);
            if (employee == null)
            {
                return NotFound(Sonuc<EmployeeDTOResponse>.SuccessNoDataFound());
            }
            await _employeeService.RemoveAsync(employee);
            return Ok(Sonuc<bool>.SuccessWithData(true));
        }

        [HttpPost("/UpdateEmployee")]
        [ValidationFilter(typeof(EmployeeValidator))]
        public async Task<IActionResult> UpdateEmployee(EmployeeDTORequest employeeDTORequest)
        {
            Employee employee = await _employeeService.GetAsync(x=>x.Id == employeeDTORequest.Id);
            if(employee == null)
            {
                return NotFound(Sonuc<EmployeeDTOResponse>.SuccessNoDataFound());
            }
            employee = _mapper.Map(employeeDTORequest,employee);

            await _employeeService.UpdateAsync(employee);
            EmployeeDTOResponse employeeDTOResponse = _mapper.Map<EmployeeDTOResponse>(employee);
            return Ok(Sonuc<EmployeeDTOResponse>.SuccessWithData(employeeDTOResponse));
        }

        [HttpGet("/Employees")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetAllAsync(x=>x.IsActive==true && x.IsDeleted ==false , "Department", "Role","Company");
            if (employees == null)
            {
                return NotFound(Sonuc<EmployeeDTOResponse>.SuccessNoDataFound());
            }
            List<EmployeeDTOResponse> employeeDTOResponseList = new();
            foreach (var employee in employees)
            {
                employeeDTOResponseList.Add(_mapper.Map<EmployeeDTOResponse>(employee));
            }
            return Ok(Sonuc<List<EmployeeDTOResponse>>.SuccessWithData(employeeDTOResponseList));
        }

        [HttpGet("/Employee/{employeeId}")]
        public async Task<IActionResult> GetEmployee(Guid employeeId)
        {
            Employee employee = await _employeeService.GetAsync(x => x.Id == employeeId);
            if (employee == null)
            {
                return NotFound(Sonuc<EmployeeDTOResponse>.SuccessNoDataFound());
            }
            EmployeeDTOResponse employeeDTOResponse = _mapper.Map<EmployeeDTOResponse>(employee);
            return Ok(Sonuc<EmployeeDTOResponse>.SuccessWithData(employeeDTOResponse));
        }
    }
}
