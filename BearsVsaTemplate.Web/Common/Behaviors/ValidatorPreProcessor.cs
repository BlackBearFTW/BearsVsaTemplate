using FluentValidation;
using Immediate.Handlers.Shared;

namespace BearsVsaTemplate.Web.Common.Behaviors;

public sealed class ValidatorPreProcessor<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators
) : Behavior<TRequest, TResponse>
{
    private readonly IReadOnlyCollection<IValidator<TRequest>> _validators = validators.ToList();

    public override async ValueTask<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .ToList();

        if (failures.Count > 0)
            throw new ValidationException(failures);

        return await Next(request, cancellationToken);
    }
}