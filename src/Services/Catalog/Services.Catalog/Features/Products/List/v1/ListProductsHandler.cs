using Services.Catalog.Features.Suppliers;

namespace Services.Catalog.Features.Products.List.v1;

public sealed class ListProductsHandler([FromKeyedServices("catalog:read")] IEfReadRepository<Product> readRepository)
    : ICoreQueryHandler<ListProductsQuery, Result<IReadOnlyCollection<ProductDto>>>
{
    public async Task<Result<IReadOnlyCollection<ProductDto>>> Handle(ListProductsQuery query,
                                                                      CancellationToken cancellationToken)
    {
        Guard.Against.Null(query);

        var products = await readRepository.ListAsync(cancellationToken);

        return products.Count == 0
                   ? Result.NotFound("No products found.")
                   : Result.Success(products.ToProductDtos());
    }
}
