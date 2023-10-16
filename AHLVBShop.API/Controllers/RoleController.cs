using AHLVBShop.API.Aspects;
using AHLVBShop.API.Validation.FluentValidation;
using AHLVBShop.Business.Abstract;
using AHLVBShop.Entity.DTO.RoleDTO;
using AHLVBShop.Entity.Poco;
using AHLVBShop.Entity.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AHLVBShop.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpPost("/AddRole")]
        [ValidationFilter(typeof(RoleValidator))]
        public async Task<IActionResult> AddRole(RoleDTORequest roleDTORequest)
        {
            Role role = _mapper.Map<Role>(roleDTORequest);
            await _roleService.AddAsync(role);

            RoleDTOResponse roleDTOResponse = _mapper.Map<RoleDTOResponse>(role);
            return Ok(Sonuc<RoleDTOResponse>.SuccessWithData(roleDTOResponse));
        }

        [HttpPost("/RemoveRole")]
        public async Task<IActionResult> RemoveRole(Guid roleId)
        {
            Role role = await _roleService.GetAsync(x => x.Id == roleId);
            if (role == null)
            {
                return NotFound(Sonuc<bool>.SuccessNoDataFound());
            }

            await _roleService.RemoveAsync(role);
            return Ok(Sonuc<bool>.SuccessWithData(true));

        }

        [HttpPost("/UpdateRole")]
        [ValidationFilter(typeof(RoleValidator))]
        public async Task<IActionResult> UpdateRole(RoleDTORequest roleDTORequest)
        {
            Role role = await _roleService.GetAsync(x => x.Id == roleDTORequest.Id);
            if (role == null)
            {
                return NotFound(Sonuc<RoleDTOResponse>.SuccessNoDataFound());
            }


            //role.RoleName = roleDTORequest.RoleName;

            role = _mapper.Map(roleDTORequest, role);

            await _roleService.UpdateAsync(role);
            RoleDTOResponse roleDTOResponse = _mapper.Map<RoleDTOResponse>(role);
            return Ok(Sonuc<RoleDTOResponse>.SuccessWithData(roleDTOResponse));


        }

        [HttpGet("/Roles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleService.GetAllAsync();
            if (roles == null)
            {
                return NotFound(Sonuc<List<RoleDTOResponse>>.SuccessNoDataFound());
            }


            List<RoleDTOResponse> roleDTOResponseList = new();
            foreach (var role in roles)
            {
                roleDTOResponseList.Add(_mapper.Map<RoleDTOResponse>(role));
            }
            return Ok(Sonuc<List<RoleDTOResponse>>.SuccessWithData(roleDTOResponseList));

        }

        [HttpGet("/Role/{roleId}")]
        public async Task<IActionResult> GetRole(Guid roleId)
        {
            Role role = await _roleService.GetAsync(x=>x.Id == roleId);
            if (role == null)
            {
                return NotFound(Sonuc<RoleDTOResponse>.SuccessNoDataFound());
            }
            RoleDTOResponse roleDTOResponse = _mapper.Map<RoleDTOResponse>(role);
            return Ok(Sonuc<RoleDTOResponse>.SuccessWithData(roleDTOResponse));
        }
    }
}
