using AHLVBShop.API.Aspects;
using AHLVBShop.API.Validation.FluentValidation;
using AHLVBShop.Business.Abstract;
using AHLVBShop.Entity.DTO.RoleDTO;
using AHLVBShop.Entity.DTO.UserDTO;
using AHLVBShop.Entity.Poco;
using AHLVBShop.Entity.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AHLVBShop.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService,IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("/AddUser")]
        [ValidationFilter(typeof(UserValidator))]
        public async Task<IActionResult> AddUser(UserDTORequest userDTORequest)
        {
            User user = _mapper.Map<User>(userDTORequest);
            await _userService.AddAsync(user);

            UserDTOResponse userDTOResponse = _mapper.Map<UserDTOResponse>(user);
            return Ok(Sonuc<UserDTOResponse>.SuccessWithData(userDTOResponse));
        }

        [HttpPost("/UpdateUser")]
        [ValidationFilter(typeof(UserValidator))]
        public async Task<IActionResult> UpdateUser(UserDTORequest userDTORequest)
        {
            User user = await _userService.GetAsync(x=>x.Id == userDTORequest.Id);
            if (user == null)
            {
                return NotFound(Sonuc<UserDTOResponse>.SuccessNoDataFound());
            }
            else
            {
                //user.UserFirstName = userDTORequest.UserFirstName;
                //user.UserLastName = userDTORequest.UserLastName;
                //user.UserName = userDTORequest.UserName;
                //user.Password = userDTORequest.Password;
                //user.Email = userDTORequest.Email;
                //user.Phone  = userDTORequest.Phone;

                user = _mapper.Map(userDTORequest, user);

                await _userService.UpdateAsync(user);
                UserDTOResponse userDTOResponse = _mapper.Map<UserDTOResponse>(user);
                return Ok(Sonuc<UserDTOResponse>.SuccessWithData(userDTOResponse));
            }
        }

        [HttpPost("/RemoveUser")]
        public async Task<IActionResult> RemoveUser(Guid userId)
        {
            User user = await _userService.GetAsync(x=> x.Id == userId);
            await _userService.RemoveAsync(user);
            if (user == null)
            {
                return NotFound(Sonuc<bool>.SuccessNoDataFound());
            }
            return Ok(Sonuc<bool>.SuccessWithData(true));
        }

        [HttpGet("/Users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllAsync(x=>x.IsActive ==true && x.IsDeleted == false,"Role");
            if (users == null)
            {
                return NotFound(Sonuc<List<UserDTOResponse>>.SuccessNoDataFound());
            }
            List<UserDTOResponse> userDTOResponseList = new();
            foreach (var user in users)
            {
                userDTOResponseList.Add(_mapper.Map<UserDTOResponse>(user));
            }
            return Ok(Sonuc<List<UserDTOResponse>>.SuccessWithData(userDTOResponseList));
        }

        [HttpGet("/User/{userId}")]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            User user = await _userService.GetAsync(x=>x.Id == userId);
            if (user == null)
            {
                return NotFound(Sonuc<UserDTOResponse>.SuccessNoDataFound());
            }
            UserDTOResponse userDTOResponse = _mapper.Map<UserDTOResponse>(user);
            return Ok(Sonuc<UserDTOResponse>.SuccessWithData(userDTOResponse));
        }
    }
}
