using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CafeOrderManagementSystem.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public readonly IMediator _mediator;
        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> HandleRequestAsync<TRequest>(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(request!, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
