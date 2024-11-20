using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOrderManagementSystem.Application.Features.TableFeature.DeleteTableById
{
    public sealed record DeleteTableByIdCommand(int Id):IRequest<string>;

}
