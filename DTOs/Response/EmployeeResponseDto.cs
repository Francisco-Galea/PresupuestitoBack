﻿namespace PresupuestitoBack.DTOs.Response
{
    public class EmployeeResponseDto
    {
        public int EmployeeId { get; set; }
        public PersonResponseDto Person { get; set; }
        public decimal Salary { get; set; }
    }
}
