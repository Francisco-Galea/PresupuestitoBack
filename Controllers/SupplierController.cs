﻿using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly SupplierService supplierService;

        public SupplierController(SupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        [HttpPost]
        public async Task CreateSupplier([FromBody] SupplierRequestDto supplierRequestDto)
        {
            await supplierService.CreateSupplier(supplierRequestDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateSupplier(int id, [FromBody] SupplierRequestDto supplierRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await supplierService.UpdateSupplier(id, supplierRequestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierResponseDto>> GetSupplierById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var supplier = await supplierService.GetSupplierById(id);
            return Ok(supplier);
        }

        [HttpGet]
        public async Task<ActionResult<List<SupplierResponseDto>>> GetAllSuppliers()
        {
            return await supplierService.GetAllSuppliers();
        }

        [HttpPatch("{id}")]
        public async Task DeleteSupplier(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await supplierService.DeleteSupplier(id);
        }
    }
}
