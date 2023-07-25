namespace DepositoHelados.Application.Responses;

public class JsonErrorResponse
{
    public int StatusCode { get; set; }
    public bool Ok { get; set; }
    public string? Message { get; set; }

    public JsonErrorResponse(int statusCode, string? message = null)
    {
        StatusCode = statusCode;
        Message = message;
        Ok = GetSuccess();
    }

    private bool GetSuccess() => StatusCode >= 200 && StatusCode < 300;
}

