namespace Services.Catalog.Features.Products.List.v1;

public sealed record ListProductsQuery : ICoreQuery<Result<IReadOnlyCollection<ProductDto>>>;
