using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOrderManagementSystem.Application.Features.ProductFeature.UpdateProduct
{
    public sealed record UpdateProductCommand(int Id,string Name, string Description, string Price, int CategoryId) : IRequest<string>;
}
