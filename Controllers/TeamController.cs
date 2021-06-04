using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domain.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using backend.DTO;

namespace backend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TeamController : ControllerBase
  {
    private readonly ITeamRepository _teamRepository;

    public TeamController(ITeamRepository teamRepository)
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
    public async Task<ActionResult<List<Team>>> GetTeams()
    {
      var teams = await _teamRepository.GetAll();
      return Ok(teams);
    }

    [HttpPost]
    public async Task<ActionResult> PostTeam(TeamDto teamDTO)
    {
      var team = new Team
      {
        Name = teamDTO.Name,
      };

      var _team = await _teamRepository.Post(team);
      return Ok(_team);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTeam(int id, TeamDto teamDTO)
    {
      Team team = new()
      {
        Name = teamDTO.Name,
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