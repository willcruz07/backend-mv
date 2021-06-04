using backend.Models;
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
    public IActionResult Get(int id)
    {
      var team = _teamRepository.Get(id);
      if (team == null)
        return NotFound();

      return Ok(team);
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Ok(_teamRepository.GetAll());
    }

    [HttpPost]
    public IActionResult Post([FromBody] TeamDto teamDTO)
    {
      if (teamDTO == null)
        return BadRequest();

      var team = new Team
      {
        Name = teamDTO.Name,
      };

      return Ok(_teamRepository.Post(team));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTeam(int id, TeamDto teamDTO)
    {
      Team team = new()
      {
        Name = teamDTO.Name,
      };

      return Ok(_teamRepository.Update(team));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      _teamRepository.Delete(id);
      return NoContent();
    }

  }
}