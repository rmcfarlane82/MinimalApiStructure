using MediatR;

namespace Application.AddNewProduct;

public class AddNewProductHandler : IRequestHandler<AddNewProductRequest, AddNewProductResult>
    {
        public Task<AddNewProductResult> Handle(AddNewProductRequest request, CancellationToken cancellationToken)
        {
            var result = new AddNewProductResult(Guid.NewGuid(), request.Name, request.Description, request.Price);
    
            return Task.FromResult(result);
        }
    }