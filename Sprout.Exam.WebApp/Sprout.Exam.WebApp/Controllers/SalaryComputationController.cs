using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.Business.Services.Interfaces;
using Sprout.Exam.Business.Contracts.Request;

namespace Sprout.Exam.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryComputationController : ControllerBase
    {
        private readonly ISalaryComputationService _salaryComputationService;
        public SalaryComputationController(ISalaryComputationService salaryComputationService)
        {
            _salaryComputationService = salaryComputationService;
        }


        [HttpGet("GetByEmployeeType/{id}")]
        public async Task<IActionResult> GetByEmployeeType(int id)
        {
            var result = await _salaryComputationService.GetByEmployeeType(id);
            return Ok(result);
        }
    }
}
