namespace Services.Catalog.Api.Endpoints.Products.Create.v1;

public sealed class CreateProductRequest
{
    [FromForm]
    public ProductModel Product { get; set; }
    
}

public sealed class ProductModel
{
    public string? Name { get; set; }
    public string? Size { get; set; }
    public decimal Price { get; set; }
    public decimal PriceSale { get; set; }
    public Guid CategoryId { get; set; }
    public Guid BrandId { get; set; }
    public Guid SupplierId { get; set; }
}
