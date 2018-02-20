using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using NotesCreatorDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoteDTO>()
                .HasOne(c => c.ConsultantName)
                .WithMany()
                .HasForeignKey("ConsultantNameID")
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<NoteActionDTO>()
                .HasOne(c => c.ActionName)
                .WithMany()
                .HasForeignKey("ActionNameID")
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Consultant> Consultants { get; set; }

        public DbSet<NoteAction> NoteAction { get; set; }
    }

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args) =>
            Program.BuildWebHost(args).Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }
}
