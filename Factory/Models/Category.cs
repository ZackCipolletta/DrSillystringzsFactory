using System.Collections.Generic;

namespace Factory.Models
{
  public class Category
  {
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public List<Machine> Machines { get; set; }
  }
}