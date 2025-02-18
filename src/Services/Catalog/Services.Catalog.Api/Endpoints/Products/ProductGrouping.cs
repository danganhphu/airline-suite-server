using Services.Catalog.Api.Endpoints.Suppliers;

namespace Services.Catalog.Api.Endpoints.Products;

public sealed class ProductGrouping : Group
{
    public ProductGrouping()
    {
        Configure(
            "v{version:apiVersion}/supplier",
            ep =>
            {
                ep.Description(
                    x => x.Produces(401)
                          .WithTags(nameof(SupplierGrouping))
                          .WithVersionSet(">>Products<<")
                          .MapToApiVersion(1.0));
            });
    }
}
