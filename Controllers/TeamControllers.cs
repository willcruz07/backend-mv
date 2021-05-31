using System.Collections.Generic;
using System.Threading.Tasks;
using backend.DTOs;
using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TeamControllers : ControllerBase
  {
    private readonly ITeamRepository _teamRepository;

    public TeamControllers(ITeamRepository teamRepository)
    {
      _teamRepository = teamRepository;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Team>> GetTeam(int id)
    {
      var team = await _teamRepository.Get(id);
      if (team == null)
        return NotFound();

      return Ok(team);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
    {
      var teams = await _teamRepository.GetAll();
      return Ok(teams);
    }

    [HttpPost]
    public async Task<ActionResult> PostTeam(CreateTeamDTO createTeamDTO)
    {
      var team = new Team
      {
        Name = createTeamDTO.Name,
      };

      await _teamRepository.Post(team);
      return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTeam(int id, UpdateTeamDTO updateTeamDTO)
    {
      Team team = new()
      {
        Name = updateTeamDTO.Name,
      };
      await _teamRepository.Update(team);
      return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTeam(int id)
    {
      await _teamRepository.Delete(id);
      return Ok();
    }

  }
}