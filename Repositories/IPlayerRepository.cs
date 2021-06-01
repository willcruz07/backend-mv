using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Repositories
{
  public interface IPlayerRepository
  {
    Task<Player> Get(int id);
    Task<IEnumerable<Player>> GetAll();
    Task<Player> Post(Player player);
    Task<Player> Update(Player player);
    Task Delete(int id);
  }
}