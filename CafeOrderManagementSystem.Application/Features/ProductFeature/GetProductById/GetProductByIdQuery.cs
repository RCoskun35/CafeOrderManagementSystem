using CafeOrderManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOrderManagementSystem.Application.Features.ProductFeature.GetProductById
{
    public sealed record GetProductByIdQuery(int Id) : IRequest<Product>;


}
