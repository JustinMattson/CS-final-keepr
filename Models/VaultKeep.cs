using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
  public class DTOVaultKeep
  {
    public int id { get; set; }

    [Required]
    public int vaultId { get; set; }

    [Required]
    public int keepId { get; set; }

    [Required]
    public string userId { get; set; }
  }
}