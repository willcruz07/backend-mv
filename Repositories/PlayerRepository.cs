using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
  public class PlayerRepository : IPlayerRepository
  {
    private readonly DataContext _context;

    public PlayerRepository(DataContext context)
    {
      _context = context;
    }

    public void Delete(int id)
    {
      var itemToDelete = _context.Players.SingleOrDefault(p => p.Id.Equals(id));
      if (itemToDelete == null)
        throw new NullReferenceException();

      _context.Players.Remove(itemToDelete);
      _context.SaveChanges();
    }

    public Player Get(int id)
    {
      return _context.Players.SingleOrDefault(p => p.Id.Equals(id));
    }

    public List<Player> GetAll()
    {
      return _context.Players.ToList();
    }

    public Player Post(Player player)
    {
      _context.Players.Add(player);
      _context.SaveChanges();

      return player;
    }

    public Player Update(Player player)
    {
      var itemToUpdate = _context.Players.SingleOrDefault(p => p.Id.Equals(player.Id));
      if (itemToUpdate == null)
        throw new NullReferenceException();

      itemToUpdate.Name = player.Name;
      itemToUpdate.Team = player.Team;

      _context.SaveChanges();

      return player;
    }
  }
}