using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using StoreService.Database;
using StoreService.Database.Models;
using StoreService.Functionality;
using Purchase = StoreService.Models.Request.Purchase;

namespace StoreService.Endpoints;

public  class PurchaseEndpoint
{
    public static void MapEndpoints(WebApplication app)
    {
        app.MapPut("/purchase/create", async (StoreDb db, Purchase.PurchaseCreateRequest request, HttpRequest rq) =>
            {
                //get id from bearer token
                var bearerToken = rq.Headers.Authorization.FirstOrDefault()?.Split(' ').Last();
                if (string.IsNullOrWhiteSpace(bearerToken))
                    return Results.BadRequest("Invalid token");

                if (!int.TryParse(Token.ExtractTokenInformation(bearerToken, JwtRegisteredClaimNames.Sid),
                        out int userId))
                    return Results.BadRequest("Invalid token");

                if (!db.Users.Any(f => f.Id == userId))
                    return Results.BadRequest("Invalid token");


                var products = db.Products.ToList().Join(request.ProductIds, p => p.Id, id => id, (p, id) => p).ToList();
                if(products.Count() != request.ProductIds.Count())
                    return Results.BadRequest($"Invalid product ids ({ string.Join(",",request.ProductIds.Where(w => !products.Select(s => s.Id).Contains(w))) })");

                var userPurchase = new UserPurchase
                {
                    User = db.Users.First(f => f.Id == userId),
                    Purchase = new Database.Models.Purchase
                    {
                        TotalPrice = products.Sum(s => s.Price),
                        FixedPriceProducts = products.Select(s => new FixedPriceProduct
                        {
                            Product = s,
                            PurchasePrice = s.Price
                        }).ToList()
                    }
                };
                await db.UserPurchases.AddAsync(userPurchase);
                await db.SaveChangesAsync();

                var response = new Models.Response.Purchase.PurchaseCreateResponse()
                {
                    PurchaseId = userPurchase.Purchase.Id,
                    TotalPrice = userPurchase.Purchase.TotalPrice
                };
                
                return Results.Ok(response);
            }).WithOpenApi()
            .RequireAuthorization()
            .Produces<Models.Response.Purchase.PurchaseCreateResponse>()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status401Unauthorized)
            .WithTags("3: Purchase");

        app.MapGet("/purchase/list", async (StoreDb db, HttpRequest rq) =>
            {
                var bearerToken = rq.Headers.Authorization.FirstOrDefault()?.Split(' ').Last();
                if (string.IsNullOrWhiteSpace(bearerToken))
                    return Results.BadRequest("Invalid token");

                if (!int.TryParse(Token.ExtractTokenInformation(bearerToken, JwtRegisteredClaimNames.Sid),
                        out int userId))
                    return Results.BadRequest("Invalid token");

                if (!db.Users.Any(f => f.Id == userId))
                    return Results.BadRequest("Invalid token");

                var userPurchases = db.UserPurchases
                    .Where(w => w.User.Id == userId)
                    .Select(s => s.Purchase)
                    .Select(s => new Models.Response.Purchase.PurchaseListResponse
                    {
                        Id = s.Id,
                        TotalPrice = s.TotalPrice,
                        PurchaseDate = s.PurchaseDate,
                        PurchasedProducts = s.FixedPriceProducts.Select(ss =>
                            new Models.Response.Purchase.PurchasedProductResponse
                            {
                                Id = ss.Product.Id,
                                Name = ss.Product.Name,
                                Description = ss.Product.Description,
                                PrimaryImage = ss.Product.PrimaryImage!.Base64,
                                PurchasePrice = ss.PurchasePrice
                            })
                    });

                return Results.Ok(await userPurchases.ToListAsync());
            }).WithOpenApi()
            .RequireAuthorization()
            .Produces<List<Models.Response.Purchase.PurchaseListResponse>>()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status401Unauthorized)
            .WithTags("3: Purchase");
    }
}