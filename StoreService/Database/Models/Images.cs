using System.ComponentModel.DataAnnotations;

namespace StoreService.Database.Models;

public class Images
{
    [Key] public int Id { get; set; }
    [MaxLength(int.MaxValue)] public string Base64 { get; set; } = "";
}