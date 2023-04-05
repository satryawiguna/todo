using System;
using Microsoft.AspNetCore.Identity;
using ToDo.Models.User;

namespace ToDo.Repository.Contract
{
    public interface IAuthRepository
	{
        Task<IEnumerable<IdentityError>> Register(RegisterDto registerDto);

        Task<AuthResponseDto> Login(LoginDto loginDto);

        Task<string> CreateRefreshToken();

        Task<AuthResponseDto> VerifyRefreshToken(RefreshTokenDto refreshTokenDto);
    }
}

