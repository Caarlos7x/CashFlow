using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        return new ResponseRegisteredExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);

        if (titleIsEmpty)
        {
            throw new ArgumentException("The title is required!");
        }

        if (request.Value <= 0)
        {
            throw new ArgumentException("Th Value must be greater than 0");
        }

        var resultDateTime = DateTime.Compare(request.Date, DateTime.UtcNow);

        if (resultDateTime > 0) 
        {
            throw new ArgumentException("Expenses cannot be fot the future!");
        }

        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);

        if (paymentTypeIsValid == false) 
        {
            throw new ArgumentException("Payment Type is not valid!");
        }

    }
}
