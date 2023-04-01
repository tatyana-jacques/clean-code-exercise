using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddAutoMapper(typeof(EmployeeService));
        }
    }
}
