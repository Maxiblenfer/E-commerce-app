﻿using Back_End.IServices;
using Back_End.Models;
using Back_End.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Back_End.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMailService mailService;

        public UserController(IUserService userService,IMailService mailService)
        {
            this.userService = userService;
            this.mailService = mailService;
        }
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            try
            {
                
                user.names = user.names.ToUpper().Trim();
                user.lastnames = user.lastnames.ToUpper().Trim();
                user.gender= user.gender.ToUpper().Trim();
                user.password = BCrypt.Net.BCrypt.HashPassword(user.password);
                var activateduser = new ActivatedUser();
                activateduser.activated = 0;
                
                activateduser.url = Hasher.GenerateHash("");
                
                await userService.RegisterUser(user,activateduser);
                mailService.SendEmailAutorization(user,activateduser.url);
                return Ok(new { message = "succesful" });
            }
            catch (Exception)
            {

                return BadRequest(new { error = "error" });
            }
        }

        [HttpGet]
        [Route("GetUserData")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetUserData()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int iduser = JwtConfigurator.getTokenIdUser(identity);
                var user = await userService.GetUser(iduser);
                return Ok(user);
            }
            catch (Exception e)
            {

                return BadRequest(new { error = e.Message });
            }
        }
        [HttpGet]
        [Route("GetActivatedUser")]
        public async Task<IActionResult> GetActivatedUser(string url)
        {
            try
            {
                return Ok(await userService.GetActivatedUser(url));
            }
            catch (Exception)
            {

                return BadRequest(new {error="error"});
            }
        }

        [HttpPut]
        [Route("ActivateUser")]
        public async Task<IActionResult> ActivateUser(int id)
        {
            try
            {
                var activateduser = new ActivatedUser();
                activateduser.activated = 0;

                activateduser.url = Hasher.GenerateHash("");
                await userService.ActivateUser(id);
                return Ok(new {message="activated"});
            }
            catch (Exception)
            {

                return BadRequest(new { error = "error" });
            }
        }
    }
}
