using Microsoft.EntityFrameworkCore;
using MerchantManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantManagementApp.DataLayer
{
    public class MerchantManagementAppDbContext : DbContext
    {
        public MerchantManagementAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Merchant> Merchants { get; set; }
    }

}