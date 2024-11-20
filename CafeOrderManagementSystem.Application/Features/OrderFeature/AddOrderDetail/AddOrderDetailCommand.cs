using CafeOrderManagementSystem.Application.Features.OrderFeature.CreateOrder;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOrderManagementSystem.Application.Features.OrderFeature.AddOrderDetail
{
    public sealed record AddOrderDetailCommand(int Id,List<OrderDetailDto> OrderDetails) : IRequest<string>;
}
