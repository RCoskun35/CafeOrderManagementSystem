using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOrderManagementSystem.Application.Features.CategoryFeature.UpdateCategory
{
    public sealed record UpdateCategoryCommand(int Id,string Name): IRequest<string>;
}
