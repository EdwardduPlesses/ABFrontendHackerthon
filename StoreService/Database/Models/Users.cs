using System.ComponentModel.DataAnnotations;
using StoreService.Functionality;

namespace StoreService.Database.Models;

public class Users
{
    [Key] public int Id { get; set; }

    [MaxLength(20)] public string Username { get; set; } = "";

    private readonly string? _encryptedPassword;
    
    [MaxLength(255)]
    public string Password
    {
        get => _encryptedPassword??"";
        init => _encryptedPassword = Hash.HashString(value);
    }

    public List<UserPurchase> UserPurchases { get; set; } = [];

    public static async void Seed(StoreDb db)
    {
        await db.Users.AddAsync(new Users
        {
            Username = "admin",
            Password = "password"
        });

        await db.SaveChangesAsync();
    }
}