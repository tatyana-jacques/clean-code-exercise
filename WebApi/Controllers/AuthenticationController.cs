using Aplication.DTOs;
using Aplication.Services;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("api/autenticar")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] EmployeeDTO dto)
        {
            return await _authenticationService.AuthenticateUser(dto);
        }

    }
}
