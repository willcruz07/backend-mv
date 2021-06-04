using Microsoft.EntityFrameworkCore;
using backend.Domain.Models;

namespace backend.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Team> Teams { get; set; }
    public DbSet<Competition> Competitions { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Player> Players { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<Team>().ToTable("Teams");
      builder.Entity<Team>().HasKey(t => t.Id);
      builder.Entity<Team>().HasMany<Player>(t => t.Players).WithOne(p => p.Team).HasForeignKey(p => p.TeamId);

      builder.Entity<Player>().ToTable("Players");
      builder.Entity<Player>().HasKey(p => p.Id);
      builder.Entity<Player>().HasOne<Team>(p => p.Team).WithMany(p => p.Players).HasForeignKey(p => p.TeamId);

      builder.Entity<Competition>().ToTable("Competitions");
      builder.Entity<Competition>().HasKey(c => c.Id);


      builder.Entity<Match>().ToTable("Matches");
      builder.Entity<Match>().HasKey(m => m.id);
    }
  }
}
