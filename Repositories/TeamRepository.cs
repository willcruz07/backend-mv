using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Data;
using backend.Domain.Models;
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
    public async Task Delete(int id)
    {
      var itemToDelete = await _context.Teams.FindAsync(id);

      if (itemToDelete == null)
        throw new NullReferenceException();

      _context.Teams.Remove(itemToDelete);
      await _context.SaveChangesAsync();
    }

    public async Task<Team> Get(int id)
    {
      return await _context.Teams.SingleAsync(t => t.Id == id);
    }

    public async Task<List<Team>> GetAll()
    {
      var teams = await _context.Teams.ToListAsync();
      return teams;
    }

    public async Task<Team> Post(Team team)
    {
      _context.Teams.Add(team);
      await _context.SaveChangesAsync();

      return team;
    }

    public async Task<Team> Update(Team team)
    {
      var itemToUpdate = await _context.Teams.FindAsync(team.Id);
      if (itemToUpdate == null)
        throw new NullReferenceException();

      itemToUpdate.Name = team.Name;
      await _context.SaveChangesAsync();

      return team;
    }
  }
}