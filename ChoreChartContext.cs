using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoreChartAPI
{
    public class ChoreChartContext : DbContext
    {
        public ChoreChartContext(DbContextOptions<ChoreChartContext> options) : base(options)
        {

        }

        public DbSet<Chore> Chores { get; set; }

        public DbSet<Day> Days { get; set; }

    }
}
