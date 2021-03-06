using System;
using api.Models;
using api.Models.Incoming;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UsersController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public Response<User> Login([FromBody]UserLogin loginData)
        {
            try {
                var loggedInUser = _userService.Login(loginData.Email, loginData.Password);
                return Response<User>.SuccessResponse(loggedInUser);
            }
            catch(Exception e) {
                return Response<User>.ErrorResponse(e.Message);
            }
        }
    }
}