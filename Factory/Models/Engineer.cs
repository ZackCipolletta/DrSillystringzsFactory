using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
    public enum EngineerStatus
  {
    Idle,
    Working
  }
  public class Engineer
  {
    public int EngineerId { get; set; }
    [Required(ErrorMessage = "Machine name cannot be empty. Please enter a name.")]
    [RegularExpression(@"^(?=.*[a-zA-Z])[a-zA-Z ]+$", ErrorMessage = "Name should only contain letters")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name should be between 2 and 50 characters")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Details cannot be empty. Please enter details.")]
    [RegularExpression(@"^(?=.*[^\s])\w[\w\s]*$", ErrorMessage = "Description should only contain letters and numbers")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "Description should be between 10 and 100 characters")]
    public string Details { get; set; }
    public EngineerStatus Status { get; set; } = EngineerStatus.Idle;
    public List<EngineerMachine> JoinEntities { get; }
  }
}