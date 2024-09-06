﻿using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [ApiController]
    [Route("api/Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost]
        public async Task createEmployee(EmployeeDto employeeDto)
        {
            await employeeService.createEmployee(employeeDto);
        }

        [HttpPut("{id}")]
        public async Task updateEmployee(EmployeeDto employeeDto)
        {
            await employeeService.updateEmployee(employeeDto);
        }

        [HttpGet("{id}")]
        public async Task<EmployeeDto> getEmployeeById(int id)
        {
            return await employeeService.getEmployeeById(id);
        }

        [HttpGet]
        public async Task<List<EmployeeDto>> getAllEmployee()
        {
            return await employeeService.getEmployees();
        }
    }
}
