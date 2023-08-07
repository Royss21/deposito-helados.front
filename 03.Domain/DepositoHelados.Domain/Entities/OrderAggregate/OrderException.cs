namespace DepositoHelados.Domain.Entities.OrderAggregate;

public class OrderException : Exception
{
    public OrderException(string message) : base(message)
    {

    }
}