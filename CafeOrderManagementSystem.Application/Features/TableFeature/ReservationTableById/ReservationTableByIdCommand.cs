using CafeOrderManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOrderManagementSystem.Application.Features.TableFeature.ReservationTableById
{
    public sealed record ReservationTableByIdCommand(int Id) : IRequest<string>;


}
