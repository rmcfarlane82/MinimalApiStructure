# Structuring a minimal Api
This repository shows an example of how you could structure a minimal api

## Program.cs
First the Program.cs makes a call to 
``` cs
  app.MapEndpoints();
```
this calls into Endpoints/Mapping namespace

## EndpointMapping.cs
This class is for registering all of your endpoints in this project there is one endpoint to map
```cs
  public static void MapEndpoints(this WebApplication app)
  {
      app.MapAddNewProductEndpoint();
  }
```

## AddNewProductEndpoint.cs
This is a minimal api endpoint for adding a new product.
In this file first it has the mapping
```cs
  public static void MapAddNewProductEndpoint(this WebApplication app)
  {
      app.MapPost(Routes.AddNewProduct, AddNewProduct)
          .WithDescription("Add a new product to the catalog.")
          .Produces<AddNewProductResult>(StatusCodes.Status201Created)
          .ProducesValidationProblem()
          .WithOpenApi();
  }
```
And in the same file it has the Endpoint
```cs
  private static async Task<IResult> AddNewProduct(AddNewProductRequest request, IMediator mediator, CancellationToken cancellationToken)
  {
      var result = await mediator.Send(request, cancellationToken);
  
      return Results.Created($"/products/{result.Id}", result);
  }
```
This is the complete endpoint
```cs
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
```

Hope you find an interesting approach to developing dotnet minimal api's

