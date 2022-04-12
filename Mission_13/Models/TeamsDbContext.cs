using System;
using Microsoft.EntityFrameworkCore;

namespace Mission_13.Models
{
    public class TeamsDbContext : DbContext
    {
        public TeamsDbContext(DbContextOptions<TeamsDbContext> options) : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }
    }
}
