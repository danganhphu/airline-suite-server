namespace Services.Catalog.Api.Endpoints.Products;

public sealed record ProductResponse(Guid? ProductId,
                                     string? Name,
                                     string? Size,
                                     decimal? Price,
                                     decimal? PriceSale,
                                     string? Category,
                                     string? Brand,
                                     string? Supplier);
