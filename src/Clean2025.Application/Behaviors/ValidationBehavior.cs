using FluentValidation;
using MediatR;
using FluentValidation.Results;

namespace Clean2025.Application.Behaviors
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
    {
        private readonly IValidator<TRequest> _validators;
        public ValidationBehavior(IValidator<TRequest> validators)
        {
            _validators = validators;
        }
        

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators == null)
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);
            var validationResult = _validators.Validate(context);

            if (!validationResult.IsValid)
            {
                var errorDictionary = validationResult.Errors
                    .Where(e => e != null)
                    .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Distinct().ToArray()
                    );

                throw new ValidationException((IEnumerable<ValidationFailure>)errorDictionary);
            }

            return await next();
        }
    }
}