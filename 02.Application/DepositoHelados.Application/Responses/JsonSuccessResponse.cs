namespace DepositoHelados.Application.Responses;

public class JsonSuccessResponse<TData>
{
    public TData Data { get; set; }
    public bool Ok { get; set; }
    public string? Message { get; set; }

    public JsonSuccessResponse(TData data, string message, bool ok = true)
    {
        Message = message;
        Ok = ok;
        Data = data;
    }
}

