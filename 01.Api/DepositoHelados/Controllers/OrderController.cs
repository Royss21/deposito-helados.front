
using DepositoHelados.Application.Responses;
using DepositoHelados.Application.Services.OrderService._03.Dtos;
using DepositoHelados.Domain.Commons;
using MediatR;

public static class OrderController
{
    public static void RegisterEndpoints(WebApplication app)
    {
        app.MapPost($"order/",
            async (CreateOrderDto order, IMediator _mediator) =>
            {
                var result = await _mediator.Send(order);
                return Results.Ok(new JsonSuccessResponse<bool>(result, Constants.Messages.SUCCESS_MESSAGE));
            })
            .WithTags("Order");

        app.MapPut($"order/",
            async (UpdateOrderDto request, IMediator _mediator) =>
            {
                var result = await _mediator.Send(request);
                return Results.Ok(new JsonSuccessResponse<bool>(result, Constants.Messages.SUCCESS_MESSAGE));
            })
            .WithTags("Order");
    }
}