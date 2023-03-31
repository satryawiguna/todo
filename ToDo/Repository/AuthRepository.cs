using System;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ToDo.Datas;
using ToDo.Models.User;
using ToDo.Repository.Contract;

namespace ToDo.Repository
{
	public class AuthRepository : IAuthRepository
	{
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public AuthRepository(IMapper mapper, UserManager<User> userManager)
        {
            this._mapper = mapper;
            this._userManager = userManager;
        }

        public async Task<bool> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            bool isValidUser = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (user is null || isValidUser)
            {
                return false;
            }


            return true;
        }

        public async Task<IEnumerable<IdentityError>> Register(RegisterDto registerDto)
        {
            var user = this._mapper.Map<User>(registerDto);
            user.UserName = registerDto.Email;

            var result = await this._userManager.CreateAsync(user, registerDto.Password );

            if (result.Succeeded)
            {
                await this._userManager.AddToRoleAsync(user, "Guest");
            }

            return result.Errors;
        }


    }
}

