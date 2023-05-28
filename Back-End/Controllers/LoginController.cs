using Back_End.DTO;
using Back_End.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(Login login)
        {
            var user =await loginService.GetUserbyEmail(login.email);
            if (user == null)
            {
                return BadRequest(new {message="User doesnt exist"});
            }
            else
            {
                if (BCrypt.Net.BCrypt.Verify(login.password,user.password))
                {
                    return Ok(new {message="success"});
                }
                else
                {
                    return BadRequest(new { message = "Password incorrect" });
                }
            }
        }
    }
}
