using AuthAPI.Models;
using AuthAPI.Models.Dto;
using AuthAPI.Service.IService;
using AuthAPI.Data;
using Microsoft.AspNetCore.Identity;

namespace AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AuthService(AppDbContext db, UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator) 
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;

        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

            if(user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    //Create role if role doesn't exist
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();

                }

                await _userManager.AddToRoleAsync(user, roleName);
                
                return true;
            }

            return false;

        }

        public async Task<LoginResponseDto> Login(LoginRequestDto requestDto)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == requestDto.UserName.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(user, requestDto.Password);

            if(user == null || isValid == false)
            {
                return new LoginResponseDto()
                {
                    UserDto = null,
                    Token = string.Empty
                };
            }

            //Get User role

            var role = await _userManager.GetRolesAsync(user);

            //If user was found we generate Jwt Token

            var token = _jwtTokenGenerator.GenerateToken(user, role);

            UserDto userDto = new()
            {
                Email = user.Email,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                ID = user.Id
            };

            LoginResponseDto responseDto = new()
            {
                UserDto = userDto,
                Token = token
            };

            return responseDto;
        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new()
            {
                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                Name = registrationRequestDto.Name,
                PhoneNumber= registrationRequestDto.PhoneNumber
            };

            try
            {
                //Register Functionality => Creating a User
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _db.ApplicationUsers.First(u => u.UserName == registrationRequestDto.Email);
                    UserDto userDto = new()
                    {
                        Name= userToReturn.Name,
                        PhoneNumber = userToReturn.PhoneNumber,
                        Email = userToReturn.Email,
                        ID= userToReturn.Id
                    };
                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch(Exception ex)
            {

            }

            return "Error Encountered";

        }
    }
}
