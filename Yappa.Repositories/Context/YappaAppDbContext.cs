using Microsoft.EntityFrameworkCore;
using Yappa.Models;

namespace MicroRabbit.YappaApp.Data.Context
{
    public class YappaAppDbContext : DbContext
    {
        public YappaAppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}