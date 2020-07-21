using AutoMapper;
using FinancePOC.Application.ViewModels;
using FinancePOC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancePOC.Application.AutoMapper
{
    public class DomainToViewModelProfile: Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Finances, FinanceViewModel>();
        }
    }
}
