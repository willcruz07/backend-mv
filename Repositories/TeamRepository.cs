using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
  public class TeamRepository : ITeamRepository
  {
    private readonly IDataContext _context;
    public TeamRepository(IDataContext context)
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
      return await _context.Teams.FindAsync(id);
    }

    public async Task<IEnumerable<Team>> GetAll()
    {
      return await _context.Teams.ToListAsync();
    }

    public async Task Post(Team team)
    {
      _context.Teams.Add(team);
      await _context.SaveChangesAsync();
    }

    public async Task Update(Team team)
    {
      var itemToUpdate = await _context.Teams.FindAsync(team.Id);
      if (itemToUpdate == null)
        throw new NullReferenceException();

      itemToUpdate.Name = team.Name;
      await _context.SaveChangesAsync();
    }
  }
}