﻿using AuthAPI.Models.Dto;

namespace AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto requestDto);

        Task<bool> AssignRole(string email, string roleName);
    }
}
