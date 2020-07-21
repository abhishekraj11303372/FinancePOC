using FinancePOC.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Infra.Data.Context
{
    public class FinanceDBContext: DbContext
    {
        public FinanceDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Finances> Finances { get; set; }
    }
}
