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
        [HttpGet]
        public async Task<IActionResult> GetAll(GetAllMenuQuery request,CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> GetById(GetMenuByIdQuery request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteMenuByIdCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
    }
}
