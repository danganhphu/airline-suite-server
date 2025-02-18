using Services.Catalog.Domain.ProductAggregate.Specifications;

namespace Services.Catalog.Features.Products.GetById.v1;

public sealed class GetProductByIdHandler([FromKeyedServices("catalog:read")] IEfReadRepository<Product> readRepository)
    : ICoreQueryHandler<GetProductByIdQuery, Result<ProductDto>>
{
    public async Task<Result<ProductDto>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var productId = Guard.Against.NullOrEmpty(query.ProductId);

        var product = await readRepository.FirstOrDefaultAsync(new ProductByIdSpec(productId), cancellationToken);

        return product is null
                   ? Result.NotFound($"Product item with id {query.ProductId} not found")
                   : product.ToProductDto();
    }
}
