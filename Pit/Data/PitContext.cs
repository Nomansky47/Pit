using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Pit
{
    public partial class PitContext : DbContext
    {
        public PitContext()
            : base("name=PitModel")
        {
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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Patronymic)
                .IsUnicode(false);

            modelBuilder.Entity<Visitors>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Visitors>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Visitors>()
                .Property(e => e.Patronymic)
                .IsUnicode(false);

            modelBuilder.Entity<Visitors>()
                .HasMany(e => e.Reserved)
                .WithRequired(e => e.Visitors)
                .WillCascadeOnDelete(false);
        }
    }
}
