using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Repositories
{
  public interface ITeamRepository
  {
    Task<Team> Get(int id);
    Task<IEnumerable<Team>> GetAll();
    Task<Team> Post(Team team);
    Task<Team> Update(Team team);
    Task Delete(int id);
  }
}