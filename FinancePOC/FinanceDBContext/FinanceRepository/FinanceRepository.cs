using Finance.Infra.Data.Context;
using FinancePOC.Domain.Interfaces;
using FinancePOC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finance.Infra.Data.FinanceRepository
{
    public class FinanceRepository : IFinanceRepository
    {
            private FinanceDBContext _ctx;

            public FinanceRepository(FinanceDBContext ctx)
            {
                _ctx = ctx;
            }

            public void Add(Finances finance)
            {
                _ctx.Finances.Add(finance);
            }

            public IQueryable<Finances> GetFinances()
            {
                return _ctx.Finances;
            }
        }
}
