using CafeOrderManagementSystem.Application.Services;
using CafeOrderManagementSystem.Application.StaticServices;
using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.UserFeature.Login
{
    public sealed class LoginCommandHandler(
            IRepository<User> repository,
            IJwtProvider jwtProvider
        ) : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await repository.GetByExpressionAsync(x => x.Email == request.Email);
            if (user == null)
                throw new Exception("User not found");

            if(user.Password != HashService.Encrypt(request.Password))
                throw new Exception("Invalid password");    

            var token =await jwtProvider.CreateTokenAsync(user);
            return token;

        }
    }
}
