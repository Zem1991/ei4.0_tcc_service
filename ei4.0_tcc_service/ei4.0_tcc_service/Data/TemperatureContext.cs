using TemperatureDb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TemperatureDb.Data
{
    public class TemperatureContext : DbContext
    {
        public TemperatureContext(DbContextOptions<TemperatureContext> options)
        : base(options)
        {
        }

        public DbSet<TemperatureRecord> Temperatures { get; set; }
    }
}