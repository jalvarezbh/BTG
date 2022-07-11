using CaixaDomain.Models;
using FluentValidation;

namespace CaixaService.Validators
{   
    public class SaquesValidator : AbstractValidator<Saques>
    {
        public SaquesValidator()
        {
            RuleFor(c => c.Valor).GreaterThanOrEqualTo(0).WithMessage("O Valor do Saque deve ser maior que 0.")
                .NotNull().WithMessage("O Valor do Saque deve ser maior que 0.");
            
        }
    }
}
