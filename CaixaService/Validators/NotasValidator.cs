using CaixaDomain.Models;
using FluentValidation;

namespace CaixaService.Validators
{
    public class NotasValidator : AbstractValidator<Notas>
    {
        public NotasValidator()
        {
            RuleFor(c => c.Quantidade).GreaterThanOrEqualTo(0).WithMessage("A quantidade deve ser positiva.")
                .NotNull().WithMessage("A quantidade deve ser positiva.");

        }
    }
}
