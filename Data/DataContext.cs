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
  }
}
