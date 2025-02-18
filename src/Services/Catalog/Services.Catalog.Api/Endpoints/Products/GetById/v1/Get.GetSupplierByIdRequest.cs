namespace Services.Catalog.Api.Endpoints.Products.GetById.v1;

public sealed class GetSupplierByIdRequest
{
    [BindFrom("id")]
    public Guid Id { get; set; }
}
