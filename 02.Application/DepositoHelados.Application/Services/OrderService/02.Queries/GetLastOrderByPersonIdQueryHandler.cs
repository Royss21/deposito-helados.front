using DepositoHelados.Application.Services.OrderService._03.Dtos;

namespace DepositoHelados.Application.Services.OrderService._02.Queries;

internal class GetLastOrderByPersonIdQueryHandler :BaseHandler, IRequestHandler<GetLastOrderByPersonIdQuery, List<GetLastOrderDto>>
{
    public GetLastOrderByPersonIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : base(unitOfWork, mapper)
    { }

    public async Task<List<GetLastOrderDto>> Handle(GetLastOrderByPersonIdQuery request, CancellationToken cancellationToken)
    {


        return null;
    }
}
