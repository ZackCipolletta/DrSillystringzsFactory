using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public string Description { get; set; }
    public int MachineId { get; set; }
    public int CategoryId { get; set;}
    public DateTime DueDate { get; set; }
    public Boolean Completed { get; set; } = false;  
    public Category Category { get; set; }
    public List<EngineerMachine> JoinEntities { get; }
  }
}
