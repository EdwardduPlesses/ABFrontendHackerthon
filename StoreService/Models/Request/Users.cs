namespace StoreService.Models.Request;

public class Users
{
    public record LoginRequest(string Username, string Password);
}