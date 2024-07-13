namespace Products.Api.Endpoints.Mapping;

public static class EndpointMapping
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapAddNewProductEndpoint();
    }
}