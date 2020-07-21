using Finance.Infra.Data.Context;
using FinancePOC.Application.Interfaces;
using FinancePOC.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancePOC.UI.WebPortal.Controllers
{
    public class FinanceController : Controller
    {
        private readonly FinanceDBContext _context;

        public FinanceController(FinanceDBContext context)
        {
            _context = context;
        }

        //Get : api/FinanceDetail/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Finances>>> GetFinances()
        {
            return await _context.Finances.ToListAsync();
        }
    }
}
