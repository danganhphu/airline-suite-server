using Services.Catalog.Domain.ProductAggregate.Specifications;

namespace Services.Catalog.Features.Products.Delete.v1;

public sealed class DeleteProductHandler([FromKeyedServices("catalog")] IEfRepository<Product> repository)
    : ICoreCommandHandler<DeleteProductCommand, Result>
{
    public async Task<Result> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var id = Guard.Against.NullOrEmpty(command.Id);

        var product = await repository.GetByIdAsync(new ProductByIdSpec(id), cancellationToken);

        if (product is null)
        {
            return Result.NotFound($"Product item with id {id} not found");
        }
        await repository.DeleteAsync(product, cancellationToken);

        return Result.Success();
    }
}
