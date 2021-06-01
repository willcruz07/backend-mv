using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
  public class PlayerRepository : IPlayerRepository
  {
    private readonly IDataContext _context;

    public PlayerRepository(IDataContext context)
    {
      _context = context;
    }

    public async Task Delete(int id)
    {
      var itemToDelete = await _context.Players.FindAsync(id);
      if (itemToDelete == null)
        throw new NullReferenceException();

      _context.Players.Remove(itemToDelete);
      await _context.SaveChangesAsync();
    }

    public async Task<Player> Get(int id)
    {
      return await _context.Players.FindAsync(id);
    }

    public async Task<IEnumerable<Player>> GetAll()
    {
      return await _context.Players.ToListAsync();
    }

    public async Task<Player> Post(Player player)
    {
      _context.Players.Add(player);
      await _context.SaveChangesAsync();

      return player;
    }

    public async Task<Player> Update(Player player)
    {
      var itemToUpdate = await _context.Players.FindAsync(player);
      if (itemToUpdate == null)
        throw new NullReferenceException();

      itemToUpdate.Name = player.Name;
      itemToUpdate.Team = player.Team;
      await _context.SaveChangesAsync();

      return player;
    }
  }
}