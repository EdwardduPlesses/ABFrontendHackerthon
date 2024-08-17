using System.ComponentModel.DataAnnotations;

namespace StoreService.Database.Models;

public class UserPurchase
{
    [Key] public int Id { get; set; }
    public Users User { get; set; } = null!;
    public Purchase Purchase { get; set; } = null!;
}