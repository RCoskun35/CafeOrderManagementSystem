using CafeOrderManagementSystem.Application.Features.CategoryFeature.GetAllCategory;
using CafeOrderManagementSystem.Application.Features.ProductFeature.CreateProduct;
using CafeOrderManagementSystem.Application.Features.ProductFeature.DeleteProductById;
using CafeOrderManagementSystem.Application.Features.ProductFeature.GetAllProduct;
using CafeOrderManagementSystem.Application.Features.ProductFeature.GetProductById;
using CafeOrderManagementSystem.Application.Features.ProductFeature.UpdateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CafeOrderManagementSystem.Web.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }
        public async Task<IActionResult> Index()
        {
            var categories =await _mediator.Send(new GetAllCategoryQuery());
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(GetAllProductQuery request,CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> GetById(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
    }
}
