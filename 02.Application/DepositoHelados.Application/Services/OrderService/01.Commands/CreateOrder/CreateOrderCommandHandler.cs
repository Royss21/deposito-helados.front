﻿using DepositoHelados.Application.Services.OrderService._03.Dtos;
using DepositoHelados.Application.Services.OrderService._05.Shared;
using DepositoHelados.Application.Shared;
using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;
using DepositoHelados.Domain.Entities.OrderAggregate;

namespace DepositoHelados.Application.Services.OrderService._01.Commands.CreateOrder;

internal class CreateOrderCommandHandler : BaseHandler, IRequestHandler<CreateOrderDto, bool>
{
    public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    { }

    public async Task<bool> Handle(CreateOrderDto request, CancellationToken cancellationToken)
    {
        var personRole = await SharedFunctions.GetPersonRole(request.PersonId, request.RoleCode, _unitOfWork);
        var typeOrder = await SharedOrderFunctions.GetOrderType(request.OrderTypeCode, _unitOfWork);
        var status = await SharedFunctions.GetMasterDetail(Constants.Codes.MASTER_STATUS, _unitOfWork);

        var order = new Order(personRole.Id);
        order.SetMdOrderTypeId(typeOrder.Id);
        order.SetCampusId(request.CampusId);
        order.SetAmountReceived(request.AmountReceived);

        order.AddTrackingStatus(new OrderTracking(status.First( f => f.Code.Equals(Constants.Codes.MD_STATUS_REGISTERED)).Id));

        var productsExisting = await SharedFunctions.GetProductsById(request.OrderItems.Select(s => s.ProductId).ToList(), _unitOfWork);

        foreach (var item in request.OrderItems)
        {
            if (!productsExisting.Any(pe => pe.Id.Equals(item.ProductId)))
                throw new EmployeeOrderProductException(Constants.Messages.PRODUCT_NOT_EXISTS.ReplaceArgs($"{request.OrderItems.IndexOf(item) + 1}"));

            if (productsExisting.Any(pe => pe.Id.Equals(item.ProductId) && !pe.IsActive))
                throw new EmployeeOrderProductException(Constants.Messages.PRODUCT_INACTIVE.ReplaceArgs($"{request.OrderItems.IndexOf(item) + 1}"));

            order.AddOrUpdateProductItem(new OrderDetail(
                item.ProductId, 
                item.MdUnitMeasurementId, 
                item.TotalQuantity, 
                item.DevolutionQuantity, 
                item.ProductPrice,
                item.IsAmountCalculate));
        }

        if(order.AunFaltaPagar(personRole.Role.Code))
        {
            order.AddTrackingStatus(new OrderTracking(status.First(f => f.Code.Equals(Constants.Codes.MD_STATUS_PENDING_PAYMENT)).Id));
            order.AddAdvanceAmount(new OrderAdvanceAmount(request.AmountReceived));
        }
        else
        {
            order.AddTrackingStatus(new OrderTracking(status.First(f => f.Code.Equals(Constants.Codes.MD_STATUS_PAYMENT)).Id));
            order.AddTrackingStatus(new OrderTracking(status.First(f => f.Code.Equals(Constants.Codes.MD_STATUS_CULMINATED)).Id));
        }

        if(personRole.Role.Code.Equals(Constants.Codes.ROLE_EMPLOYEE))
        {
            var orderProducts = await _unitOfWork
                    .Repository
                    .EmployeeOrderProductRepository
                    .GetAllAsync(g => request.OrderProductsIds.Contains(g.Id));

            var person = await _unitOfWork
                    .Repository
                    .PersonRepository
                    .FirstAsync(g => g.PersonRoles.First(f => f.Id == personRole.Id).PersonAmountAccounts.Any(w => request.AmountsAccountIds.Contains(w.Id)));

            order.AssignProductOrders(orderProducts.ToList());
            order.AssignAmountsAccount(person.PersonRoles.First().PersonAmountAccounts.ToList());
        }

        order.ChangeLastStatus();

        await _unitOfWork
                .Repository
                .OrderRepository
                .AddAsync(order);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}

