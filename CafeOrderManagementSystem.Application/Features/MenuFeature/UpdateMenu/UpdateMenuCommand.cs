using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOrderManagementSystem.Application.Features.MenuFeature.UpdateMenu
{
    public sealed record UpdateMenuCommand(int Id,string Name): IRequest<string>;
}
