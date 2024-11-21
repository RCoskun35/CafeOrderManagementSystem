using System.Diagnostics;
using CafeOrderManagementSystem.Application.Features.TableFeature.GetAllTable;
using CafeOrderManagementSystem.Application.UserManagement;
using CafeOrderManagementSystem.Infrastructure.Services;
using CafeOrderManagementSystem.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace CafeOrderManagementSystem.Web.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(IMediator mediator) : base(mediator)
        {
        }


        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var tables = await _mediator.Send(new GetAllTableQuery(), cancellationToken);
            return View(tables);
        }

        
    }
}
