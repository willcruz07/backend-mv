using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domain.Models;

namespace backend.Repositories
{
  public interface ITeamRepository
  {
    Task<Team> Get(int id);
    Task<List<Team>> GetAll();
    Task<Team> Post(Team team);
    Task<Team> Update(Team team);
    Task Delete(int id);
  }
}