namespace Services.Catalog.Api.Endpoints.Products.Delete.v1;

public sealed class DeleteSupplierRequest
{
    [BindFrom("id")]
    public Guid Id { get; set; }
}
