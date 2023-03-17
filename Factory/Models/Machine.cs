using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public int MachineId { get; set; }
 
    public List<EngineerMachine> JoinEntities { get; }
  }
}
