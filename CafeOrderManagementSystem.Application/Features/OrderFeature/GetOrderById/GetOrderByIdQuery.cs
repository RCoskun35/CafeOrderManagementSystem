using CafeOrderManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOrderManagementSystem.Application.Features.OrderFeature.GetOrderById
{
    public sealed record GetOrderByIdQuery(int Id) : IRequest<Order>;


}
