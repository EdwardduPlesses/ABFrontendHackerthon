namespace StoreService.Models.Request;

public  class Products
{
    public  record ProductsListRequest
    {
        public int Page
        {
            get;
            set;
        } = 0;

        public int PageSize
        {
            get;
            set;
        } = 20;
        public string[] Tags
        {
            get;
            set;
        } = [];
        public string Search
        {
            get;
            set;
        } = "";
    }

    public  record ProductsCreateRequest
    {
        public string Name
        {
            get;
            set;
        } = "";
        public string Description
        {
            get;
            set;
        } = "";
        public decimal Price
        {
            get;
            set;
        }
        public string PrimaryImage
        {
            get;
            set;
        } = "";
        public IEnumerable<string> Images { get; set; } = [];
        public IEnumerable<string> Tags { get; set; } = [];
    }

    public  record ProductsUpdateRequest
    {
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        } = "";
        public string Description
        {
            get;
            set;
        } = "";
        public decimal Price
        {
            get;
            set;
        }
        public string PrimaryImage
        {
            get;
            set;
        } = "";
        public List<string> Images { get; set; } = new();
        public List<string> Tags { get; set; } = new();
    }
}