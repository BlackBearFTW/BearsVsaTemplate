using FluentValidation;

namespace BearsVsaTemplate.Web.Features.Todos.Endpoints.Create;

public class CreateValidator : AbstractValidator<Create.Command>
{
    public CreateValidator()
    {
        RuleFor(x => x.Content).NotNull();
    }
}