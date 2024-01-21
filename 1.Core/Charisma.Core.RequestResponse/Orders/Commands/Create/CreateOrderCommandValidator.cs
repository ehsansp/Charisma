using FluentValidation;
using Zamin.Extensions.Translations.Abstractions;

namespace Charisma.Core.RequestResponse.Orders.Commands.Create
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator(ITranslator translator)
        {
            RuleFor(c => c.CustomerId);
        }
    }
}
