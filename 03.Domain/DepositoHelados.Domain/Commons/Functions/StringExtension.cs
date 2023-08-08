namespace DepositoHelados.Domain.Commons.Functions;

public static class StringExtension
{
    public static string ReplaceArgs(this string value, params string[] arguments)
    {
        return string.Format(value, arguments);
    }
}