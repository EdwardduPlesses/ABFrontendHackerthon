using Microsoft.EntityFrameworkCore;
using StoreService.Database;
using StoreService.Models.Response;

namespace StoreService.Endpoints;

public  class TagsEndpoint
{

    public static void MapEndpoints(WebApplication app)
    {
        app.MapGet("/tags/list",
                async (StoreDb db) =>
                    await db.Tags.Select(s => new Tags.TagsListResponse(s.Id, s.Name)).ToListAsync())
            .WithOpenApi()
            .Produces<List<Tags.TagsListResponse>>()
            .WithTags("1: Tags");
    }
}