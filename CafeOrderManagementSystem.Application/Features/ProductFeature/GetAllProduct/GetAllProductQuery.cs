using CafeOrderManagementSystem.Domain.Entities;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.ProductFeature.GetAllProduct
{
    public sealed record GetAllProductQuery() : IRequest<List<Product>>;
}
