using Microsoft.EntityFrameworkCore;
using StoreService.Database;
using StoreService.Functionality;
using StoreService.Models.Response;

namespace StoreService.Endpoints;

public static class UserEndpoint
{
    public static void MapEndpoints(WebApplication app)
    {
        app.MapPost("/users/login", async (Models.Request.Users.LoginRequest request, StoreDb db) =>
            {
                var user = await db.Users.FirstOrDefaultAsync(f => f.Username == request.Username &&
                                                                   f.Password == Hash.HashString(request.Password));

                if (user == null) return Results.Unauthorized();

                Users.LoginResponse response = new(user.Id, Token.GenerateToken(app, user));
                return Results.Ok(response);
            })
            .WithOpenApi()
            .Produces<Users.LoginResponse>()
            .Produces(StatusCodes.Status401Unauthorized)
            .WithTags("0: Users");

        app.MapGet("/users/list",
                async (StoreDb db) =>
                    await db.Users.Select(s => new Users.UsersResponse(s.Id, s.Username)).ToListAsync())
            .WithOpenApi()
            .RequireAuthorization()
            .Produces<List<Users.UsersResponse>>()
            .Produces(StatusCodes.Status401Unauthorized)
            .WithTags("0: Users");
    }
}