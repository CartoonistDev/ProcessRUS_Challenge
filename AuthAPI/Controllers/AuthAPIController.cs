using AuthAPI.Models.Dto;
using AuthAPI.Service.IService;
using AuthAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDto _responseDto;

        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
            _responseDto = new();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto requestDto)
        {
            var auth = await _authService.Register(requestDto);
            if (!string.IsNullOrEmpty(auth))
            {
                _responseDto.isSuccess = false;
                _responseDto.Message = auth;

                return BadRequest(_responseDto);
            }
            return Ok(_responseDto);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto requestDto)
        {
            var loginResponse = await _authService.Login(requestDto);
            if (loginResponse.UserDto == null)
            {
                _responseDto.isSuccess = false;
                _responseDto.Message = "Username or password incorrect";

                return BadRequest(_responseDto);
            }
            _responseDto.Message = "Login Successful";
            _responseDto.Result = loginResponse;
            return Ok(_responseDto);
        }

        [HttpPost("assignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto requestDto)
        {
            var assignRoleResponse = await _authService.AssignRole(requestDto.Email, requestDto.RoleName.ToUpper());
            if (!assignRoleResponse)
            {
                _responseDto.isSuccess = false;
                _responseDto.Message = "Role Assign Not Successful";

                return BadRequest(_responseDto);
            }
            _responseDto.Result = assignRoleResponse;
            return Ok(_responseDto);
        }
    }
}
