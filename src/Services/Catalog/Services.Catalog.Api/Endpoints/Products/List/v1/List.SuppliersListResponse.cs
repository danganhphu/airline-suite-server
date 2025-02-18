namespace Services.Catalog.Api.Endpoints.Products.List.v1;

public sealed class SuppliersListResponse
{
    public IReadOnlyCollection<ProductResponse> Suppliers { get; set; } = [];
}
