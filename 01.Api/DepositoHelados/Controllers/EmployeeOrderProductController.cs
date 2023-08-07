
using DepositoHelados.Application.Responses;
using DepositoHelados.Application.Services.EmployeeOrderProductService.Dtos;
using DepositoHelados.Application.Services.EmployeeOrderProductService.Queries;
using DepositoHelados.Domain.Commons;
using MediatR;

public static class EmployeeOrderProductController
{
    public static void RegisterEndpoints(WebApplication app)
    {
        app.MapPost($"order-product/",
            async (CreateOrderProductDto request, IMediator _mediator) =>
            {
                var result = await _mediator.Send(request);
                return Results.Ok(new JsonSuccessResponse<bool>(result, Constants.Messages.SUCCESS_MESSAGE));
            })
            .WithTags("OrderProduct");

        app.MapPut($"order-product/",
            async (UpdateOrderProductDto request, IMediator _mediator) =>
            {
                var result = await _mediator.Send(request);
                return Results.Ok(new JsonSuccessResponse<bool>(result, Constants.Messages.SUCCESS_MESSAGE));
            })
            .WithTags("OrderProduct");

        app.MapGet("order-product/{personId}/without-order-relation",
            async (Guid personId, IMediator _mediator) =>
            {
                var result = await _mediator.Send(new GetOrderProductWithoutOrderQuery { PersonId = personId});
                return Results.Ok(new JsonSuccessResponse<List<GetOrderProductWithoutOrderDto>>(result, Constants.Messages.SUCCESS_MESSAGE));
            })
            .WithTags("OrderProduct");
    }
}