using FinancePOC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinancePOC.Domain.Interfaces
{
    public interface IFinanceRepository
    {
        IQueryable<Finances> GetFinances();
        void Add(Finances finances);
    }
}
