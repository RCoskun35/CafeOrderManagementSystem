using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOrderManagementSystem.Application.Features.CategoryFeature.DeleteCategoryById
{
    public sealed record DeleteCategoryByIdCommand(int Id):IRequest<string>;

}
