namespace StoreService.Models.Request;

public  class Purchase
{
    public  record PurchaseCreateRequest
    {
        public IEnumerable<int> ProductIds { get; set; } = [];
    }
    
}