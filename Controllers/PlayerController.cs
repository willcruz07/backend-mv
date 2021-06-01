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
    public async Task<ActionResult<Player>> Get(int id)
    {
      var player = await _playerRepository.Get(id);
      if (player == null)
        return NotFound();

      return Ok(player);
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<IEnumerable<Player>>> GetAll()
    {
      var player = await _playerRepository.GetAll();
      return Ok(player);
    }

    [HttpPost]
    public async Task<ActionResult> Post(PlayerDto playerDTO)
    {
      var player = new Player
      {
        Name = playerDTO.Name,
        Team = playerDTO.Team
      };

      var _player = await _playerRepository.Post(player);
      return Ok(_player);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, PlayerDto playerDTO)
    {
      Player player = new()
      {
        Name = playerDTO.Name,
        Team = playerDTO.Team,
      };
      var _player = await _playerRepository.Update(player);
      return Ok(_player);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTeam(int id)
    {
      await _playerRepository.Delete(id);
      return Ok();
    }



  }
}