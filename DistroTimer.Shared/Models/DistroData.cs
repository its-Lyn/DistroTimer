using System.ComponentModel.DataAnnotations;

namespace DistroTimer.Shared.Models;

public class DistroData
{
    [Key] public int DistroId { get; set; }

    [Required] public required string DistroName { get; set; }
    [Required] public required DateTime StartDate { get; set; }
}