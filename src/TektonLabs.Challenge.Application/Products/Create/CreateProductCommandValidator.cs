using FluentValidation;
using TektonLabs.Challenge.Application.Products.CreateProduct;

namespace TektonLabs.Challenge.Application.Products.Create;
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Stock).GreaterThanOrEqualTo(0);
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Stock).GreaterThanOrEqualTo(0);

        RuleFor(x => x.Status).GreaterThanOrEqualTo(0);

        //    .MustAsync(async (status, cancellation) =>
        //{
        //    var statusType = await _statusTypeRepository.GetByIdAsync(status, cancellation);
        //    return !(statusType is null);
        //}).WithMessage("Tipo de Estado no Valido");
    }
}