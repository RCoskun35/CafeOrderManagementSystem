using CafeOrderManagementSystem.Application.Features.CategoryFeature.CreateCategory;
using CafeOrderManagementSystem.Application.Features.CategoryFeature.DeleteCategoryById;
using CafeOrderManagementSystem.Application.Features.CategoryFeature.GetAllCategory;
using CafeOrderManagementSystem.Application.Features.CategoryFeature.GetCategoryById;
using CafeOrderManagementSystem.Application.Features.CategoryFeature.UpdateCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CafeOrderManagementSystem.Web.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(IMediator mediator) : base(mediator)
        {
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetAll([FromBody] GetAllCategoryQuery request,CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById([FromBody] DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
    }
}
