namespace Services.Catalog.Features.Products.Delete.v1;

public sealed record DeleteProductCommand(Guid Id) : ICoreCommand<Result>;
