using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Engineer
  {
    public int EngineerId { get; set; }
    [Required(ErrorMessage = "Engineer name cannot be empty. Please enter a name.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name should be between 2 and 50 characters")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name should only contain letters")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Details cannot be empty. Please enter details.")]
    [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Description should only contain letters and numbers")]
    [StringLength(100, MinimumLength = 10, ErrorMessage = "Description should be between 10 and 100 characters")]
    public string Details { get; set; }
    public List<EngineerMachine> JoinEntities { get; }
  }
}