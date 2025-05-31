using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Database.AppDbContext
{


public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<User> Users {get; set;}
    public DbSet<Ticket> Tickets {get; set;}
    public DbSet<PC> PCs {get; set;}
    
    public DbSet<Ram> Ram {get; set;}
    public DbSet<Mobo> Mobo {get; set;}
    public DbSet<Cpu> Cpu {get; set;}
    public DbSet<Case> Case {get; set;}
    public DbSet<Gpu> Gpu {get; set;}
    public DbSet<Storage> Storage {get; set;}
    public DbSet<Psu> Psu {get; set;}

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Ticket>()
    .HasOne(t => t.PC)
    .WithMany()
    .HasForeignKey(t => t.PCId);

    modelBuilder.Entity<Ticket>()
        .HasOne(t => t.Internet)
        .WithMany()
        .HasForeignKey(t => t.InternetId);

    modelBuilder.Entity<Ticket>()
        .HasOne(t => t.PcOpti)
        .WithMany()
        .HasForeignKey(t => t.PcOptiId);

    modelBuilder.Entity<PC>()
        .HasOne(pc => pc.Gpu)
        .WithMany()
        .HasForeignKey(pc => pc.GpuId);
         modelBuilder.Entity<PC>()
        .HasOne(pc => pc.Storage)
        .WithMany()
        .HasForeignKey(pc => pc.StorageId);

    modelBuilder.Entity<PC>()
        .HasOne(pc => pc.Cpu)
        .WithMany()
        .HasForeignKey(pc => pc.CpuId);

    modelBuilder.Entity<PC>()
        .HasOne(pc => pc.Ram)
        .WithMany()
        .HasForeignKey(pc => pc.RamId);

    modelBuilder.Entity<PC>()
        .HasOne(pc => pc.Mobo)
        .WithMany()
        .HasForeignKey(pc => pc.MoboId);

    modelBuilder.Entity<PC>()
        .HasOne(pc => pc.Psu)
        .WithMany()
        .HasForeignKey(pc => pc.PsuId);

    modelBuilder.Entity<PC>()
        .HasOne(pc => pc.Case)
        .WithMany()
        .HasForeignKey(pc => pc.CaseId);
}


}
}