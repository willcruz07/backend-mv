using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Repositories
{
  public interface ITeamRepository
  {
    Team Get(int id);
    List<Team> GetAll();
    Team Post(Team team);
    Team Update(Team team);
    void Delete(int id);
  }
}