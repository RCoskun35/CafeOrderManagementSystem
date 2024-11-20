using CafeOrderManagementSystem.Application.Features.MenuProductFeature.CreateMenuProduct;
using CafeOrderManagementSystem.Application.Features.MenuProductFeature.DeleteMenuProductByMenuIdAndProductId;
using CafeOrderManagementSystem.Application.Features.MenuProductFeature.GetMenuProductByMenuId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CafeOrderManagementSystem.Web.Controllers
{
    public class MenuProductController : BaseController
    {
        public MenuProductController(IMediator mediator) : base(mediator)
        {
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetByMenuId([FromBody] GetMenuProductByMenuIdQuery request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMenuProductCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteByMenuIdAndProductId([FromBody] DeleteMenuProductByMenuIdAndProductIdCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
    }
}
