namespace backend.Models
{
  public class Match
  {
    public int id { get; set; }
    public Competition Competition { get; set; }
    public Team TeamHouse { get; set; }
    public int TeamHouseId { get; set; }
    public Team TeamVisitor { get; set; }
    public int TeamVisitorId { get; set; }
    public int ScoreHouse { get; set; }
    public int ScoreVisitor { get; set; }
  }
}