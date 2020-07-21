using FinancePOC.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancePOC.Application.Interfaces
{
    public interface IFinanceService
    {
        IEnumerable<FinanceViewModel> GetFinances();
    }
}
