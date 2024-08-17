namespace StoreService.Models.Response;

public  class Products
{
    public record ProductsListResponse(
        int Id,
        string Name,
        string Description,
        decimal Price,
        string PrimaryImage,
        IEnumerable<string> Tags);

    public record ProductsSingleResponse(
        int Id,
        string Name,
        string Description,
        decimal Price,
        IEnumerable<string> Images,
        IEnumerable<string> Tags);
}