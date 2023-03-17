using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public string Description { get; set; }
    public int MachineId { get; set; }
    public DateTime DueDate { get; set; }
    public Boolean Completed { get; set; } = false;  
    public List<EngineerMachine> JoinEntities { get; }
  }
}
