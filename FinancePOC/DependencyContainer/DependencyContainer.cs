using FinanacePOC.Domain.Core.Bus;
using Finance.Infra.Data.Context;
using Finance.Infra.Data.FinanceRepository;
using FinancePOC.Application.Interfaces;
using FinancePOC.Application.Services;
using FinancePOC.Domain.Interfaces;
using FinancePOC.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FinancePOC.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain InMemoryBus MediatR
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //Application Layer 
            services.AddScoped<IFinanceService, FinanceService>();

            //Infra.Data Layer 
            services.AddScoped<IFinanceRepository, FinanceRepository>();
            services.AddScoped<FinanceDBContext>();
        }
    }
}
