using System.Collections.Generic;
using backend.Models;

namespace backend.Repositories
{
  public interface IPlayerRepository
  {
    Player Get(int id);
    List<Player> GetAll();
    Player Post(Player player);
    Player Update(Player player);
    void Delete(int id);
  }
}