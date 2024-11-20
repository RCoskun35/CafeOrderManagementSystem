using MediatR;

namespace CafeOrderManagementSystem.Application.Features.ProductFeature.DeleteProductById
{
    public sealed record DeleteProductByIdCommand(int Id):IRequest<string>;

}
