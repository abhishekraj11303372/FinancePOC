using Finance.Infra.Data.Context;
using Finance.Infra.Data.FinanceRepository;
using FinancePOC.Application.Interfaces;
using FinancePOC.Application.Services;
using FinancePOC.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FinancePOC.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application Layer 
            services.AddScoped<IFinanceService, FinanceService>();

            //Infra.Data Layer 
            services.AddScoped<IFinanceRepository, FinanceRepository>();
            services.AddScoped<FinanceDBContext>();
        }
    }
}
