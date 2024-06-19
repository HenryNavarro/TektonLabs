using FluentValidation;
using TektonLabs.Challenge.Domain.Products.IRepository;

namespace TektonLabs.Challenge.Application.Products.Update;
public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    private readonly IStatusTypeRepository _statusTypeRepository;
    public UpdateProductCommandValidator(IStatusTypeRepository statusTypeRepository)
    {

        _statusTypeRepository = statusTypeRepository;

        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Stock).GreaterThanOrEqualTo(0);
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Stock).GreaterThanOrEqualTo(0);

        //RuleFor(x => x.Status).MustAsync(async (status, cancellation) =>
        //{
        //    var statusType = await _statusTypeRepository.GetByIdAsync(status, cancellation);
        //    return !(statusType is null);
        //}).WithMessage("Tipo de Estado no Valido");
    }
}