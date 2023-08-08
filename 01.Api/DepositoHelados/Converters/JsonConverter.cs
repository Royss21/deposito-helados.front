
namespace DepositoHelados.Converters;

using System.Text;
using System.Text.Json;
public static class JsonConverter
{
    public static StringContent SerializeContent(this object data, string mediatype = "application/json", JsonSerializerOptions? options = null)
    {
        if (options is null)
            options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

        return new StringContent(
            JsonSerializer.Serialize(data, options),
            Encoding.UTF8,
            mediatype);
    }

    public static T? DeserializerContent<T>(this object value)
    {
        return JsonSerializer.Deserialize<T>(value?.ToString() ?? "", new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

}

