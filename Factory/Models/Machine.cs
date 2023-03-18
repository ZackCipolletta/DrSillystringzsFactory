using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Machine
  {
    [Required(ErrorMessage = "Machine name cannot be empty. Please enter a name.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name should be between 2 and 50 characters")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Description cannot be empty. Please enter a description.")]
    [RegularExpression(@"^(?=.*[^\s])\w[\w\s]*$", ErrorMessage = "Description should only contain letters and numbers")]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "Description should be between 10 and 100 characters")]
    public string Description { get; set; }
    public int MachineId { get; set; }
    public List<EngineerMachine> JoinEntities { get; }
  }
}
