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
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetAll([FromBody] GetAllProductQuery request,CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById([FromBody] DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
    }
}
