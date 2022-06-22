using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ArtWorkPromotion.API.Data;
using ArtWorkPromotion.API.Interfaces;
using ArtWorkPromotion.API.Models;
using ArtWorkPromotion.PCL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace ArtWorkPromotion.API.Services
{
	public class UserService : IUserService
	{
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<AppUser> userManager, AppDbContext dbContext, IConfiguration configuration)
		{
            _userManager = userManager;
            _context = dbContext;
            _configuration = configuration;
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginInfo loginInfo)
        {
            var user = await _userManager.FindByEmailAsync(loginInfo.Email);

            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "There is no user with that Email address",
                    IsSuccess = false
                };
            }

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginInfo.Password);

            if (!isPasswordCorrect)
            {
                var userManagerResponse = new UserManagerResponse
                {
                    Message = "Invalid password",
                    IsSuccess = false,
                    Errors = new[] { "Password does not match the provided email address" }
                };
                return userManagerResponse;
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
               _configuration["AuthSettings:Issuer"],
               _configuration["AuthSettings:Audience"],
               expires: DateTime.Now.AddDays(7),
               signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            var tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);


            return new UserManagerResponse
            {
                UserId = user.Id,
                Token = tokenAsString,
                IsSuccess = true,
                ExpireDate = token.ValidTo        
            };

        }

        public async Task<UserManagerResponse> RegisteruserAsync(RegistrationInfo registrationInfo)
        {
            UserManagerResponse userManagerResponse;

            var appUser = await _userManager.FindByEmailAsync(registrationInfo.Email);

            if (appUser != null)
            {
                userManagerResponse = new UserManagerResponse()
                {
                    Message = "Another user with that email was found in the database",
                    IsSuccess = false
                };
                return userManagerResponse;
            }

            appUser = new AppUser()
            {
                Name = registrationInfo.Name,
                Email = registrationInfo.Email,
                UserName = registrationInfo.Email,
                PhoneNumber = registrationInfo.PhoneNumber,
                Description = registrationInfo.Address,
                Brand = registrationInfo.Brand,
                Location = registrationInfo.Location,
                Address = registrationInfo.Address

            };

            var identityResult = await new PasswordValidator<AppUser>().ValidateAsync(_userManager, appUser, registrationInfo.Password);

            if (!identityResult.Succeeded)
            {
                userManagerResponse = new UserManagerResponse
                {
                    Message = "Password Validation failed",
                    IsSuccess = false,
                    Errors = identityResult.Errors.Select(e => e.Description)
                };
                return userManagerResponse;
            }

            var result = await _userManager.CreateAsync(appUser, registrationInfo.Password);

            if (!result.Succeeded)
            {
                userManagerResponse = new UserManagerResponse
                {
                    Message = "User did not create",
                    IsSuccess = false,
                    Errors = result.Errors.Select(e => e.Description)
                };
                return userManagerResponse;
            }

            userManagerResponse = new UserManagerResponse
            {
                Message = "User created successfully!",
                IsSuccess = true
            };

            return userManagerResponse;

        }
    }
}

