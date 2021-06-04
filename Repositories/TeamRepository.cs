using System;
using System.Collections.Generic;
using System.Linq;
using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
  public class TeamRepository : ITeamRepository
  {
    private readonly DataContext _context;
    public TeamRepository(DataContext context)
    {
      _context = context;
    }
    public void Delete(int id)
    {
      var itemToDelete = _context.Teams.SingleOrDefault(t => t.Id.Equals(id));

      if (itemToDelete == null)
        throw new NullReferenceException();

      _context.Teams.Remove(itemToDelete);
      _context.SaveChanges();
    }

    public Team Get(int id)
    {
      return _context.Teams.SingleOrDefault(t => t.Id.Equals(id));
    }

    public List<Team> GetAll()
    {
      return _context.Teams.Include(p => p.Players).ToList();
    }

    public Team Post(Team team)
    {
      _context.Teams.Add(team);
      _context.SaveChanges();

      return team;
    }

    public Team Update(Team team)
    {
      var itemToUpdate = _context.Teams.SingleOrDefault(t => t.Id.Equals(team.Id));
      if (itemToUpdate == null)
        throw new NullReferenceException();

      itemToUpdate.Name = team.Name;
      _context.SaveChanges();

      return team;
    }
  }
}