namespace CashFlow.Communication.Responses;
public class ResponseErrorJson
{
    public string ErrorMessages { get; set; } = string.Empty;

    public ResponseErrorJson(string errorMessage)
    {
        
    }
}
