using Domain.Entities;

namespace Aplication.Services
{
    public interface ITokenService
    {
        string GenerateToken(Employee employee);
    }
}
