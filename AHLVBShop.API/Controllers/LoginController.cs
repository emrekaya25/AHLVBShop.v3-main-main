using AHLVBShop.API.Aspects;
using AHLVBShop.API.Validation.FluentValidation;
using AHLVBShop.Business.Abstract;
using AHLVBShop.Entity.DTO.LoginDTO;
using AHLVBShop.Entity.Poco;
using AHLVBShop.Entity.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace AHLVBShop.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmployeeService _employeeService;
        private readonly IConfiguration _configuration;
        public LoginController(IUserService userService,IConfiguration configuration, IEmployeeService employeeService)
        {
            _configuration = configuration;
            _userService = userService;
            _employeeService = employeeService;

        }

        [HttpPost("/LoginUser")]
        [ValidationFilter(typeof(LoginValidator))]
        public async Task<IActionResult> LoginWithUser(LoginDTORequest loginDTORequest)
        {
            var user = await _userService.GetAsync(x => x.UserName == loginDTORequest.KullaniciAdi && x.Password == loginDTORequest.Sifre);

            if (user == null)
            {
                return NotFound(Sonuc<LoginDTOResponse>.SuccessNoDataFound());
            }
            else
            {
                var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:JWTKey"));

                var claims = new List<Claim>();
                claims.Add(new Claim("kullaniciAdi",user.UserName));
                claims.Add(new Claim("kullaniciID", user.Id.ToString()));
                claims.Add(new Claim("adSoyad",user.UserFirstName+ " " + user.UserLastName));
                
                

                var jwt = new JwtSecurityToken(
                    expires: DateTime.Now.AddDays(20),
                    notBefore: DateTime.Now,
                    claims: claims,
                    issuer: "http://localhost.com",
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    );

                var token = new JwtSecurityTokenHandler().WriteToken(jwt);

                LoginDTOResponse loginDTOResponse = new()
                {
                    AdSoyad = user.UserFirstName + " " + user.UserLastName,
                    EPosta = user.Email,
                    Token = token,
                    RoleId = user.RoleId,
                    Id = user.Id,   
                    
                    
                };
                return Ok(Sonuc<LoginDTOResponse>.SuccessWithData(loginDTOResponse));

            }
        }

        [HttpPost("/LoginEmployee")]
        [ValidationFilter(typeof(LoginValidator))]
        public async Task<IActionResult> LoginWithEmployee(LoginDTORequest loginDTORequest)
        {
            var employee = await _employeeService.GetAsync(x => x.EmployeeUserName == loginDTORequest.KullaniciAdi && x.EmployeePassword == loginDTORequest.Sifre);

            if (employee == null)
            {
                return NotFound(Sonuc<LoginDTOResponse>.SuccessNoDataFound());
            }
            else
            {
                var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:JWTKey"));

                var claims = new List<Claim>();
                claims.Add(new Claim("kullaniciAdi", employee.EmployeeUserName));
                claims.Add(new Claim("kullaniciID", employee.Id.ToString()));
                claims.Add(new Claim("adSoyad", employee.EmployeeFirstName + " " + employee.EmployeeLastName));
                

                var jwt = new JwtSecurityToken(
                    expires: DateTime.Now.AddDays(20),
                    notBefore: DateTime.Now,
                    claims: claims,
                    issuer: "http://localhost.com",
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    );

                var token = new JwtSecurityTokenHandler().WriteToken(jwt);

                LoginDTOResponse loginDTOResponse = new()
                {
                    AdSoyad = employee.EmployeeFirstName + " " + employee.EmployeeLastName,
                    EPosta = employee.Email,
                    Token = token,
                    RoleId = employee.RoleId,
                    Id = employee.Id,
                    
                };
                return Ok(Sonuc<LoginDTOResponse>.SuccessWithData(loginDTOResponse));

            }
        }


    }
}
