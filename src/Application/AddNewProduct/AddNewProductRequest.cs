using MediatR;

namespace Application.AddNewProduct;

public record AddNewProductRequest(string Name, string Description, decimal Price) : IRequest<AddNewProductResult>
{
    
}