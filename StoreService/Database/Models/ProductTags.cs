using System.ComponentModel.DataAnnotations;

namespace StoreService.Database.Models;

public class ProductTags
{
    [Key] public int Id { get; set; }
    public Products Product { get; set; } = null!;
    public Tags Tag { get; set; } = null!;
}