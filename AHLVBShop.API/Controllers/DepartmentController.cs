
using AHLVBShop.API.Aspects;
using AHLVBShop.API.Validation.FluentValidation;
using AHLVBShop.Business.Abstract;
using AHLVBShop.Entity.DTO.DepartmentDTO;
using AHLVBShop.Entity.Poco;
using AHLVBShop.Entity.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AHLVBShop.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public DepartmentController(IDepartmentService departmentService, IMapper mapper, ICompanyService companyService)
        {
            _departmentService = departmentService;
            _mapper = mapper;
            _companyService = companyService;
        }

        [HttpPost("/AddDepartment")]
        [ValidationFilter(typeof(DepartmentValidator))]
        public async Task<IActionResult> AddDepartment(DepartmentDTORequest departmentDTORequest)
        {
            Department department = _mapper.Map<Department>(departmentDTORequest);
            await _departmentService.AddAsync(department);
            DepartmentDTOResponse departmentDTOResponse = _mapper.Map<DepartmentDTOResponse>(department);
            return Ok(Sonuc<DepartmentDTOResponse>.SuccessWithData(departmentDTOResponse));
        }

        [HttpGet("/Departments")]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _departmentService.GetAllAsync(x=>x.IsActive == true && x.IsDeleted==false,"Company");
            if (departments == null)
            {
                return NotFound(Sonuc<List<DepartmentDTOResponse>>.SuccessNoDataFound());
            }
            else
            {
                List<DepartmentDTOResponse> departmentDTOResponseList = new();
                foreach (var department in departments)
                {
                    departmentDTOResponseList.Add(_mapper.Map<DepartmentDTOResponse>(department));
                }
                
                return Ok(Sonuc<List<DepartmentDTOResponse>>.SuccessWithData(departmentDTOResponseList));
            }
        }

        [HttpPost("/RemoveDepartment/{departmentId}")]
        public async Task<IActionResult> RemoveDepartment(Guid departmentId)
        {
            Department department = await _departmentService.GetAsync(x => x.Id == departmentId);
            await _departmentService.RemoveAsync(department);
            return Ok(Sonuc<bool>.SuccessWithData(true));
        }

        [HttpPost("/UpdateDepartment")]
        [ValidationFilter(typeof(DepartmentValidator))]
        public async Task<IActionResult> UpdateDepartment(DepartmentDTORequest departmentDTORequest)
        {
            Department department = await _departmentService.GetAsync(x => x.Id == departmentDTORequest.Id);
            
            if (department == null)
            {
                return NotFound(Sonuc<DepartmentDTOResponse>.SuccessNoDataFound());
            }
            else
            {
                //department.DepartmentName = departmentDTORequest.DepartmentName;
                //department.PhoneNumber = departmentDTORequest.PhoneNumber;
                //department.Address = departmentDTORequest.Address;
                //department.Email = departmentDTORequest.Email;
                
                department = _mapper.Map(departmentDTORequest, department);

                await _departmentService.UpdateAsync(department);

                DepartmentDTOResponse departmentDTOResponse = _mapper.Map<DepartmentDTOResponse>(department);
                return Ok(Sonuc<DepartmentDTOResponse>.SuccessWithData(departmentDTOResponse));
            }
        }

        [HttpGet("/Department/{departmentId}")]
        public async Task<IActionResult> GetDepartment(Guid departmentId)
        {
            Department department = await _departmentService.GetAsync(x=>x.Id == departmentId);
            if(department == null)
            {
                return NotFound(Sonuc<DepartmentDTOResponse>.SuccessNoDataFound());
            }
            DepartmentDTOResponse departmentDTOResponse = _mapper.Map<DepartmentDTOResponse>(department);
            return Ok(Sonuc<DepartmentDTOResponse>.SuccessWithData(departmentDTOResponse));
        }


    }
}
