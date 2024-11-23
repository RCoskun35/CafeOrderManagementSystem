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
        public async Task<IActionResult> GetByMenuId( GetMenuProductByMenuIdQuery request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> Create( CreateMenuProductCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteByMenuIdAndProductId( DeleteMenuProductByMenuIdAndProductIdCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
    }
}
