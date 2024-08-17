using System.ComponentModel.DataAnnotations;

namespace StoreService.Database.Models;

public class FixedPriceProduct
{
    [Key] public int Id { get; set; }

    public decimal PurchasePrice { get; set; }

    public Products Product { get; set; } = null!;
}