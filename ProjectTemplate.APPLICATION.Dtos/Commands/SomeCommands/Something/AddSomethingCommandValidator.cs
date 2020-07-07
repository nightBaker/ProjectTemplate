using FluentValidation;

namespace ProjectTemplate.APPLICATION.Dtos.Commands.SomeCommands.Something
{
    public class AddSomethingCommandValidator : AbstractValidator<AddSomethingCommand>
    {
        public AddSomethingCommandValidator()
        {
            RuleFor(x => x.SomeValue)
                .NotNull()                
                .NotEmpty();

            RuleFor(x => x.SomeEnum)
                .NotEqual(DOMAIN.Dtos.SomeEnum.None);
        }
    }
}
