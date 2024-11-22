using MediatR;

namespace CafeOrderManagementSystem.Application.Features.ProductFeature.CreateProduct
{
    public sealed record CreateProductCommand(string Name,string Description,string Price,int CategoryId) : IRequest<string>;
}
