using Aplication.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Aplication.Services
{
    public interface IAuthenticationService
    {
        Task<ActionResult<dynamic>> AuthenticateUser(EmployeeDTO dto);
    }
}
