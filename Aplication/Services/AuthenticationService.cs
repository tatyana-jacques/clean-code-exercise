using Aplication.DTOs;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly RhDbContext _context;
        private readonly ITokenService _tokenService;
        public AuthenticationService(RhDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<ActionResult<dynamic>> AuthenticateUser(EmployeeDTO dto)
        {
            try
            {
                var user = await _context.Employee.Include(x => x.Permission)
                        .FirstOrDefaultAsync(x => x.Email == dto.Email && x.Password == dto.Password);

                if (user == null)
                {
                    return new { Message = "Funcionário e/ou senha inválidos." };
                }

                var token = _tokenService.GenerateToken(user);
                var result = new
                {
                    token,
                    User = new
                    {
                        user.Id,
                        user.Name,
                        user.Email,
                        user.PermissionId
                    }
                };
                user.Password = "";
                return new { result };
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo de geração do token." };
            }
        }
    }
}
