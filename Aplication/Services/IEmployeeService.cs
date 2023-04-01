using Aplication.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace Aplication.Services
{
    public interface IEmployeeService
    {
        Task<ActionResult<dynamic>> GetEmployee();
        Task<ActionResult<dynamic>> GetEmployee(int id);
        Task<ActionResult<dynamic>> PutEmployee(int id, DTOPut change);
        Task<ActionResult<dynamic>> PostEmployee(EmployeeRequest request);
        Task<ActionResult<dynamic>> DeleteEmployee(int id);
        Task<ActionResult<dynamic>> DeleteManager(int id);
    }
}
