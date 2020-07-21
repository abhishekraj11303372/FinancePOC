using Finance.Infra.Data.Context;
using FinancePOC.Application.Interfaces;
using FinancePOC.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancePOC.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinanceController : ControllerBase
    {
        //private readonly IFinanceService _financeService;

        //public FinanceController(IFinanceService financeService)
        //{
        //    _financeService = financeService;
        //}

        //[HttpPost]
        //public IActionResult Post([FromBody] FinanceViewModel financeViewModel)
        //{
        //    _financeService.Create(financeViewModel);

        //    return Ok(financeViewModel);
        //}

        private readonly FinanceDBContext _context;

        public FinanceController(FinanceDBContext context)
        {
            _context = context;
        }


        //Get : /Finance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Finances>>> GetFinances()
        {
            var financeDetail = await _context.Finances.ToListAsync();
            if (financeDetail == null)
            {
                return NotFound();
            }
            return financeDetail;
        }
    }
}
