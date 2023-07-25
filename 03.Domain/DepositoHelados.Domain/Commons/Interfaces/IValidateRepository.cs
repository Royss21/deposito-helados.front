using FluentValidation;
using FluentValidation.Results;

namespace DepositoHelados.Domain.Commons.Interfaces;

public interface IValidateRepository<T> where T : class
{
    Task<ValidationResult> ValidateEntityAsync(T t, IValidator<T> validation);
}

