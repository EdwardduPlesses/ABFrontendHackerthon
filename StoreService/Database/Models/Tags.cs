using System.ComponentModel.DataAnnotations;

namespace StoreService.Database.Models;

public class Tags
{
    [Key] public int Id { get; set; }

    [MaxLength(20)] public string Name { get; set; } = "";

    public List<ProductTags> ProductTags { get; set; } = [];

    public static async void Seed(StoreDb db)
    {
        await db.Tags.AddRangeAsync(new Tags
            {
                Name = "Applicances"
            }, new Tags
            {
                Name = "Automotive"
            }, new Tags
            {
                Name = "DIY"
            }, new Tags
            {
                Name = "Electronics"
            }, new Tags
            {
                Name = "Furniture"
            }, new Tags
            {
                Name = "Garden"
            }, new Tags
            {
                Name = "Home"
            }, new Tags
            {
                Name = "Jewelry"
            }, new Tags
            {
                Name = "Kids"
            }, new Tags
            {
                Name = "Liquor"
            }, new Tags
            {
                Name = "Gaming"
            }, new Tags
            {
                Name = "Movies"
            }, new Tags
            {
                Name = "Music"
            }, new Tags
            {
                Name = "Office"
            }, new Tags
            {
                Name = "Pets"
            }, new Tags
            {
                Name = "Sports"
            }, new Tags
            {
                Name = "Tools"
            }, new Tags
            {
                Name = "Toys"
            }
        );

        await db.SaveChangesAsync();
    }
}