using CafeOrderManagementSystem.Application.Features.TableFeature.GetAllTable;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CafeOrderManagementSystem.Web.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(IMediator mediator) : base(mediator)
        {
        }


        public IActionResult Index()
        {
            return View(); 
        }

        public async Task<IActionResult> HomePartialView(CancellationToken cancellationToken)
        {
            var tables = await _mediator.Send(new GetAllTableQuery(), cancellationToken);
            return View(tables);
        }


    }
}
