namespace Factory.Models
{
  public class Engineer
  {
    public int EngineerId { get; set; }
    public string Title { get; set; }
    public List<EngineerMachine> JoinEntities { get; }
  }
}