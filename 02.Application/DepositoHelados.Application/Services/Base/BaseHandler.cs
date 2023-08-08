using DepositoHelados.Infraestructure.UnitOfWork;

namespace DepositoHelados.Application.Services.Base;

public abstract class BaseHandler
{
    public readonly IUnitOfWork _unitOfWork;
    public readonly IMapper _mapper;

    public BaseHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
}

