using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinanacePOC.Domain.Core.Bus;
using FinancePOC.Application.Interfaces;
using FinancePOC.Application.ViewModels;
using FinancePOC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancePOC.Application.Services
{
    public class FinanceService : IFinanceService
    {
        private IFinanceRepository _financeRepository;
        private readonly IMediatorHandler _bus;
        private readonly IMapper _autoMapper;
        public FinanceService(IFinanceRepository financeRepository, IMediatorHandler bus, IMapper automapper)
        {
            _financeRepository = financeRepository;
            _bus = bus;
            _autoMapper = automapper;
        }
        public IEnumerable<FinanceViewModel> GetFinances()
        {
            return _financeRepository.GetFinances().ProjectTo<FinanceViewModel>(_autoMapper.ConfigurationProvider);
        }
    }
}
