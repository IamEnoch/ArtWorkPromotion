using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtWorkPromotion.API.Data;
using ArtWorkPromotion.API.Interfaces;
using ArtWorkPromotion.PCL.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArtWorkPromotion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUserService _userService;

        public AuthController(AppDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserManagerResponse>> LoginUser([FromBody]LoginInfo loginInfo)
        {
            if(string.IsNullOrEmpty(loginInfo.Email) || string.IsNullOrEmpty(loginInfo.Password))
            {
                return BadRequest("Email or password cannor be empty");
            }

            return await _userService.LoginUserAsync(loginInfo);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserManagerResponse>> RegisterUser([FromBody] RegistrationInfo registrationInfo)
        {
            if (!ModelState.IsValid)
                return BadRequest("Some properties are not valid");

            return await _userService.RegisteruserAsync(registrationInfo);
        }
    }
}

