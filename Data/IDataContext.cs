using System.Threading;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
  public interface IDataContext
  {
    DbSet<Team> Teams { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
  }
}