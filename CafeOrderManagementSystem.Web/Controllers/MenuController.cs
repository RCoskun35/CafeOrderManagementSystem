using CafeOrderManagementSystem.Application.Features.MenuFeature.CreateMenu;
using CafeOrderManagementSystem.Application.Features.MenuFeature.DeleteMenuById;
using CafeOrderManagementSystem.Application.Features.MenuFeature.GetAllMenu;
using CafeOrderManagementSystem.Application.Features.MenuFeature.GetMenuById;
using CafeOrderManagementSystem.Application.Features.MenuFeature.UpdateMenu;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CafeOrderManagementSystem.Web.Controllers
{
    public class MenuController : BaseController
    {
        public MenuController(IMediator mediator) : base(mediator)
        {
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetAll([FromBody] GetAllMenuQuery request,CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] GetMenuByIdQuery request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMenuCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById([FromBody] DeleteMenuByIdCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
    }
}
