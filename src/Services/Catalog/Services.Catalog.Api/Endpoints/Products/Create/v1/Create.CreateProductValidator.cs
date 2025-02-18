namespace Services.Catalog.Api.Endpoints.Products.Create.v1;

internal sealed class CreateProductValidator : Validator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Product.Name).MaximumLength(50).WithErrorCode("ML001");

        RuleFor(x => x.Product.CategoryId)
            .NotNull().WithMessage("Category id cannot null!").WithErrorCode("Ca001");

        RuleFor(x => x.Product.BrandId)
            .NotNull().WithMessage("Brand id cannot null!").WithErrorCode("B001");

        RuleFor(x => x.Product.SupplierId)
            .NotNull().WithMessage("Supplier id cannot null!").WithErrorCode("S001");
    }
}
