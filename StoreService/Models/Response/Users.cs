namespace StoreService.Models.Response;

public  class Users
{
    public record LoginResponse(int UserId, string UserToken);
    
    public record UsersResponse(int UserId, string Username);
}