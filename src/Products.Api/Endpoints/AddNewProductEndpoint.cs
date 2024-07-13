using Application.AddNewProduct;
using MediatR;
using Products.Api.Endpoints.Mapping;

namespace Products.Api.Endpoints;

public static class AddNewProductEndpoint
{
    public static void MapAddNewProductEndpoint(this WebApplication app)
    {
        app.MapPost(Routes.AddNewProduct, AddNewProduct)
            .WithDescription("Add a new product to the catalog.")
            .Produces<AddNewProductResult>(StatusCodes.Status201Created)
            .ProducesValidationProblem()
            .WithOpenApi();
    }

    private static async Task<IResult> AddNewProduct(AddNewProductRequest request, IMediator mediator, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);

        return Results.Created($"/products/{result.Id}", result);
    }
}