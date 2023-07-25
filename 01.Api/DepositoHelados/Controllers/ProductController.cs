
using DepositoHelados.Application.Responses;
using DepositoHelados.Application.Services.ProductService.Dtos;
using DepositoHelados.Domain.Commons;
using MediatR;

public static class ProductController
{
    public static void RegisterEndpoints(WebApplication app)
    {
        app.MapPost($"product/",
            async (CreateProductDto product, IMediator _mediator) =>
            {
                var result = await _mediator.Send(product);
                return Results.Ok(new JsonSuccessResponse<bool>(result, Constants.SUCCESS_MESSAGE));
            })
            .WithTags("Product");
    }
}