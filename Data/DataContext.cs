using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
  public class DataContext : DbContext, IDataContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Team> Teams { get; set; }
    public DbSet<Competition> Competitions { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Player> Players { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<Player>().ToTable("Players");
      builder.Entity<Player>().HasKey(p => p.Id);
      builder.Entity<Player>().HasOne(p => p.Team).WithMany(p => p.Players).HasForeignKey(p => p.TeamId);

    }
  }
}
