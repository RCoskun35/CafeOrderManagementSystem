using CafeOrderManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOrderManagementSystem.Application.Features.MenuFeature.GetMenuById
{
    public sealed record GetMenuByIdQuery(int Id) : IRequest<Domain.Entities.Menu>;


}
