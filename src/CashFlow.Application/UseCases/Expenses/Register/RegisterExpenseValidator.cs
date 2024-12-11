using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage("The title is required!");
        RuleFor(expense => expense.Value).GreaterThan(0).WithMessage("The Value must be greater than 0");
        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("The Date must be less than or equal to the current date");
        RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage("Payment Type is not valid!");
    }
}
