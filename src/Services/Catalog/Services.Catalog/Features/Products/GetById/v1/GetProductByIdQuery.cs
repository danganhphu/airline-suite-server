namespace Services.Catalog.Features.Products.GetById.v1;

public sealed record GetProductByIdQuery(Guid ProductId) : ICoreQuery<Result<ProductDto>>;
