
using DepositoHelados.Application.Responses;
using DepositoHelados.Application.Services.EmployeeOrderProductService.Dtos;
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
                return Results.Ok(new JsonSuccessResponse<bool>(result, Constants.SUCCESS_MESSAGE));
            })
            .WithTags("OrderProduct");

        app.MapPut($"order-product/",
            async (UpdateOrderProductDto request, IMediator _mediator) =>
            {
                var result = await _mediator.Send(request);
                return Results.Ok(new JsonSuccessResponse<bool>(result, Constants.SUCCESS_MESSAGE));
            })
            .WithTags("OrderProduct");
    }
}