using AutoMapper.QueryableExtensions;
using DepositoHelados.Application.Services.EmployeeOrderProductService.Dtos;

namespace DepositoHelados.Application.Services.EmployeeOrderProductService.Queries
{
    internal class GetOrderProductWithoutOrderQueryHandler : BaseHandler, IRequestHandler<GetOrderProductWithoutOrderQuery, List<GetOrderProductDto>>
    {
        public GetOrderProductWithoutOrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public async Task<List<GetOrderProductDto>> Handle(GetOrderProductWithoutOrderQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork
                        .Repository
                        .EmployeeOrderProductRepository
                        .GetAllProject(g => 
                            g.PersonRole.PersonId.Equals(request.PersonId) && 
                            g.OrderId == null
                        )
                        .ProjectTo<GetOrderProductDto>(_mapper.ConfigurationProvider)
                        .ToListAsync();
        }
    }

}
