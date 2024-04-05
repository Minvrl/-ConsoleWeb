
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebConsole.Entities;

namespace WebConsole
{
    internal class AppDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MIMI\\SQLEXPRESS;Database=Store;Trusted_connection=true");
        }
    }
}
