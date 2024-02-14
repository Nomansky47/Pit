using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Pit
{
    public partial class PitContext : DbContext
    {
        public PitContext()
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Reserved> Reserved { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Visitors> Visitors { get; set; }
        private static PitContext _context {get;set;}
        public static PitContext GetContext()
        {
            if (_context == null)
                _context = new PitContext();
            return _context;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("Host=localhost;Port=5432;Database=PitBase;Username=postgres;Password=3110");
        }
    }
}
