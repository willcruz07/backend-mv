using System.Collections.Generic;

namespace backend.Domain.Models
{
  public class Team
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Player> Players { get; set; }
  }
}