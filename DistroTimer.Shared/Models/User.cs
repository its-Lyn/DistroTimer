using System.ComponentModel.DataAnnotations;

namespace DistroTimer.Shared.Models;

public class User
{
    [Key] public int UserId { get; set; }

    [Required] public required string UserName { get; set; }
    [Required] public required List<DistroData> Distros { get; set; } = [];
    [Required] public required DateTime DateAdded { get; set; }
}