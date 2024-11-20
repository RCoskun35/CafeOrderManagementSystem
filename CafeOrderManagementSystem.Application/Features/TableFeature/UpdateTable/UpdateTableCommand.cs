using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOrderManagementSystem.Application.Features.TableFeature.UpdateTable
{
    public sealed record UpdateTableCommand(int Id,string TableNumber,int State) : IRequest<string>;
}
