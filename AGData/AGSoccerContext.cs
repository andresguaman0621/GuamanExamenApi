using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuamanExamenApi.Models;

namespace GuamanExamenApi.Data
{
    public class AGSoccerContext:DbContext
    {
        public AGSoccerContext(DbContextOptions<AGSoccerContext> options) : base(options)
        {

        }

        public DbSet<Match> Matches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=EXAMENPROG3.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>().HasKey(m => m.MatchId);
            modelBuilder.Entity<Match>().Property(m => m.MatchId).ValueGeneratedOnAdd();
        }
    }
}
