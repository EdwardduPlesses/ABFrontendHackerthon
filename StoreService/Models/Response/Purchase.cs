namespace StoreService.Models.Response;

public  class Purchase
{
    public record PurchaseListResponse
    {
        public Guid Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<PurchasedProductResponse> PurchasedProducts { get; set; } = [];
    }

    public record PurchasedProductResponse
    {
        public int Id { get; set; }
        public decimal PurchasePrice { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string PrimaryImage { get; set; } = "";
    }

    public record PurchaseCreateResponse
    {
        public Guid PurchaseId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}