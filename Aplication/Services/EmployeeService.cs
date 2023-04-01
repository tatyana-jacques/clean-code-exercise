using Aplication.DTOs;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Aplication.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly RhDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(RhDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<dynamic>> GetEmployee()
        {
            try
            {
                if (_context.Employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                var employees = await _context.Employee
                 .Include(x => x.Permission)
                 .ToListAsync();

                var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
              
                    var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeResponse>()
                    .ForMember(dest => dest.Permission, act => act.MapFrom(act => act.Permission.Name)));
                    var mapper = configuration.CreateMapper();
                    var employeesDTO = mapper.Map<List<EmployeeResponse>>(employees);

                    return employeesDTO;

               
                    
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo de geração do token." };
            }
        }

        public async Task<ActionResult<dynamic>> GetEmployee(int id)
        {
            try
            {
                if (_context.Employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }
                var employee = await _context.Employee.FindAsync(id);

                if (employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                return employee;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo de geração do token." };
            }
        }

        public async Task<ActionResult<dynamic>> PutEmployee(int id, DTOPut change)
        {
            try
            {
               

                try
                {
                    var employee = await _context.Employee
                    .Include(x => x.Permission)
                    .Where(y => y.Id == id).FirstOrDefaultAsync();

                    if (employee.PermissionId == 1)
                    {
                    employee.Salary = change.Salary;
                    _context.Entry(employee).State = EntityState.Modified;
                    _context.Employee.Update(employee);
                    await _context.SaveChangesAsync();
                    return new { Message = "A identidade inserida não corresponde à de um funcionário." };


                    }
                    else
                    {
                        return new { Message = "Funcionario inexistente." };
                    }

                  
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(id))
                    {
                        return new { Message = "Não existe funcionário com o Id informado." };
                    }
                    else
                    {
                        throw;
                    }
                }

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo de geração do token." };
            }
        }


        public async Task<ActionResult<dynamic>> PostEmployee(EmployeeRequest request)
        {
            try
            {
                if (_context.Employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                var configuration =
                      new MapperConfiguration(cfg => cfg.CreateMap<EmployeeRequest, Employee>());
                var mapper = configuration.CreateMapper();
                var employee = mapper.Map<Employee>(request);

                _context.Employee.Add(employee);
                await _context.SaveChangesAsync();

                return true;
            }

            catch
            {
                return new { Message = "Ocorreu erro durante o processo de geração do token." };
            }
        }

        public async Task<ActionResult<dynamic>> DeleteEmployee(int id)
        {
            try
            {
                if (_context.Employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }
                var employee = await _context.Employee.FindAsync(id);
                if (employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo de geração do token." };
            }
        }

        public async Task<ActionResult<dynamic>> DeleteManager(int id)
        {
            try
            {
                if (_context.Employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }
                var employee = await _context.Employee.FindAsync(id);
                if (employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo de geração do token." };
            }
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employee?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
