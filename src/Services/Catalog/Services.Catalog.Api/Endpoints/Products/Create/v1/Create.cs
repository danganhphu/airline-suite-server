using Services.Catalog.Api.Endpoints.Brands.Create.v1;
using Services.Catalog.Api.Endpoints.Suppliers;
using Services.Catalog.Domain.BrandAggregate;
using Services.Catalog.Domain.CategoriesAggregate;
using Services.Catalog.Domain.SupplierAggregate;
using Services.Catalog.Features.Products.Create.v1;
using Services.Catalog.Features.Suppliers.Create.v1;

namespace Services.Catalog.Api.Endpoints.Products.Create.v1;

public sealed class Create(ISender sender) : Endpoint<CreateProductRequest, CreateBrandResponse>
{
    public override void Configure()
    {
        Post(ApiRoutes.Product.Create);

        Group<SupplierGrouping>();
    }

    public override async Task HandleAsync(CreateProductRequest request,
                                           CancellationToken ct)
    {
        var result = await sender.Send(
                         new CreateProductCommand(
                             request.Product.Name,
                             request.Product.Size,
                             request.Product.Price,
                             request.Product.PriceSale,
                             new(request.Product.CategoryId),
                             new(request.Product.BrandId),
                             new(request.Product.SupplierId)),
                         ct);

        if (result.IsSuccess)
        {
            Response = new(result.Value);

            return;
        }

        await SendResultAsync(result.ToMinimalApiResult());
    }
}
