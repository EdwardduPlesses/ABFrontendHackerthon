using Microsoft.EntityFrameworkCore;
using StoreService.Database;
using StoreService.Database.Models;
using Products = StoreService.Models.Request.Products;

namespace StoreService.Endpoints;

public static class ProductsEndpoint
{
    public static void MapEndpoints(WebApplication app)
    {
        app.MapPost("/products/list", async (StoreDb db, Products.ProductsListRequest request) =>
            {
                var tags = request.Tags.Select(s => s.ToLower());
                
                var products = db.Products
                    .Include(i => i.Images)
                    .Include(i => i.PrimaryImage)
                    .Include(i => i.ProductTags)
                    .ThenInclude(i => i.Tag)
                    .Where(w => request.Search.Length == 0 || w.Name.ToLower().Contains(request.Search.ToLower()) ||
                                w.Description.ToLower().Contains(request.Search.ToLower()))
                    .Where(w => request.Tags.Length == 0 ||
                                w.ProductTags.Select(s => s.Tag.Name.ToLower())
                                    .Any(a => tags.Contains(a)))
                    .Skip(request.Page * request.PageSize)
                    .Take(request.PageSize);

                var productsList = await products.Select(s => new Models.Response.Products.ProductsListResponse(s.Id,
                        s.Name, s.Description,
                        s.Price, s.PrimaryImage!.Base64,
                        s.ProductTags.Select(ss => ss.Tag.Name).ToList()))
                    .ToListAsync();

                return Results.Ok(productsList);
            })
            .WithOpenApi()
            .Produces<Models.Response.Products.ProductsListResponse>()
            .WithTags("2: Products");

        app.MapGet("/products/single",
                async (StoreDb db, int id) =>
                {
                    var product = await db.Products
                        .Include(products => products.ProductTags)
                        .ThenInclude(productTags => productTags.Tag)
                        .Include(products => products.PrimaryImage!)
                        .Include(products => products.Images)
                        .FirstOrDefaultAsync(w => w.Id == id);

                    if (product == null) return Results.NotFound();

                    var response = new Models.Response.Products.ProductsSingleResponse(
                        product.Id,
                        product.Name,
                        product.Description,
                        product.Price,
                        product.Images.Select(ss => ss.Base64).Prepend(product.PrimaryImage!.Base64),
                        product.ProductTags.Select(ss => ss.Tag.Name)
                    );
                    return Results.Ok(response);
                }).WithOpenApi()
            .Produces<Models.Response.Products.ProductsSingleResponse>()
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("2: Products");

        app.MapPut("/products/create", async (StoreDb db, Products.ProductsCreateRequest request) =>
            {
                var product = new Database.Models.Products
                {
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    PrimaryImage = new Images
                    {
                        Base64 = request.PrimaryImage
                    },
                    Images = request.Images.Select(s => new Images
                    {
                        Base64 = s
                    }).ToList().ToList()
                };

                await db.Products.AddAsync(product);
                await db.SaveChangesAsync();

                foreach (var tag in request.Tags)
                {
                    await product.FindOrCreateProductTag(db, tag);
                }

                return Results.Ok();
            })
            .WithOpenApi()
            .RequireAuthorization()
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status401Unauthorized)
            .WithTags("2: Products");

        app.MapPatch("/products/update", async (StoreDb db, Products.ProductsUpdateRequest request) =>
            {
                var product = await db.Products.Include(i => i.Images)
                    .Include(i => i.PrimaryImage)
                    .Include(i => i.ProductTags)
                    .ThenInclude(i => i.Tag)
                    .FirstOrDefaultAsync(f => f.Id == request.Id);

                if (product == null) return Results.NotFound();

                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = request.Price;
                product.PrimaryImage!.Base64 = request.PrimaryImage;
                product.Images = request.Images.Select(s => new Images
                {
                    Base64 = s
                }).ToList();
                product.ProductTags = [];

                await db.SaveChangesAsync();

                foreach (var tag in request.Tags)
                {
                    await product.FindOrCreateProductTag(db, tag);
                }

                return Results.Ok();
            })
            .WithOpenApi()
            .RequireAuthorization()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("2: Products");

        app.MapDelete("/products/delete", async (StoreDb db, int id) =>
            {
                var product = await db.Products.FirstOrDefaultAsync(f => f.Id == id);

                if (product == null) return Results.NotFound();

                db.ProductTags.RemoveRange(db.ProductTags.Where(w => w.Product.Id == id));
                db.Products.Remove(product);
                await db.SaveChangesAsync();

                return Results.Ok();
            })
            .WithOpenApi()
            .RequireAuthorization()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("2: Products");

        app.MapPost("/products/list/random", async (StoreDb db) =>
            {
                var products = db.Products
                    .Include(i => i.Images)
                    .Include(i => i.PrimaryImage)
                    .Include(i => i.ProductTags)
                    .ThenInclude(i => i.Tag)
                    .OrderBy(o => Guid.NewGuid())
                    .Take(8);

                var productsList = await products.Select(s => new Models.Response.Products.ProductsListResponse(s.Id,
                        s.Name, s.Description,
                        s.Price, s.PrimaryImage!.Base64,
                        s.ProductTags.Select(ss => ss.Tag.Name).ToList()))
                    .ToListAsync();

                return Results.Ok(productsList);
            })
            .WithOpenApi()
            .Produces<Models.Response.Products.ProductsListResponse>()
            .WithTags("2: Products");
    }
}