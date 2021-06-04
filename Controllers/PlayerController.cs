using System.Collections.Generic;
using System.Threading.Tasks;
using backend.DTO;
using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PlayerController : ControllerBase
  {
    private readonly IPlayerRepository _playerRepository;

    public PlayerController(IPlayerRepository playerRepository)
    {
      _playerRepository = playerRepository;
    }

    [HttpGet]
    public IActionResult Get(int id)
    {
      var player = _playerRepository.Get(id);
      if (player == null)
        return NotFound();

      return Ok(player);
    }

    [HttpGet("{id}")]
    public IActionResult GetAll()
    {
      return Ok(_playerRepository.GetAll());
    }

    [HttpPost]
    public IActionResult Post(PlayerDto playerDTO)
    {
      var player = new Player
      {
        Name = playerDTO.Name,
        TeamId = playerDTO.TeamId
      };

      return Ok(_playerRepository.Post(player));
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, PlayerDto playerDTO)
    {
      Player player = new()
      {
        Name = playerDTO.Name,
        TeamId = playerDTO.TeamId,
      };

      return Ok(_playerRepository.Update(player));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTeam(int id)
    {
      _playerRepository.Delete(id);
      return NoContent();
    }



  }
}