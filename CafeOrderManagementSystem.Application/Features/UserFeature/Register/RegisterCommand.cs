using GenericRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOrderManagementSystem.Application.Features.UserFeature.Register
{
    public sealed record RegisterCommand(string Email, string FirstName, string LastName, string Password, string RePassword) : IRequest<string>;
}
