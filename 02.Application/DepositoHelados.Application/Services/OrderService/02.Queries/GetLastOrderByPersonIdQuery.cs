using DepositoHelados.Application.Services.OrderService._03.Dtos;

namespace DepositoHelados.Application.Services.OrderService._02.Queries;

public record GetLastOrderByPersonIdQuery : IRequest<List<GetLastOrderDto>>
{
    public Guid PersonId { get; set; }
    public int CampusId { get; set; }
    public string CodeRole { get; set; } = string.Empty;
}

