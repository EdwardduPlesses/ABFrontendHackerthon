using System.ComponentModel.DataAnnotations;

namespace StoreService.Database.Models;

public class Purchase
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime PurchaseDate { get; set; } = DateTime.Now;
    public decimal TotalPrice { get; set; }
    public List<FixedPriceProduct> FixedPriceProducts { get; set; } = [];
}