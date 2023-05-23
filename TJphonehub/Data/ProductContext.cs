using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TJphonehub.Entity;
using System.Text;
using Microsoft.Data;

namespace TJphonehub.Data

{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<ProductUser> ProductUsers { get; set; }
        public DbSet<ProductSales> ProductSales { get; set; }

    }
}
