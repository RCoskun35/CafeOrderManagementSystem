using CafeOrderManagementSystem.Application.StaticServices;
using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.UserFeature.Register
{
    public class RegisterCommandHander(
        IRepository<User> repository,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<RegisterCommand, string>
    {
        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if(request.Password != request.RePassword)
                throw new Exception("Parolalar eşleşmiyor");

            var isExistUser = await repository.GetByExpressionWithTrackingAsync(x => x.Email == request.Email);
            if (isExistUser != null)
                throw new Exception("Kullanıcı mevcut");
            var user = new User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Email,
                Password =HashService.Encrypt(request.Password)
            };
            await repository.AddAsync(user);
            await unitOfWork.SaveChangesAsync();

            return "Kullanıcı başarıyla oluşturuldu";
        }
    }
}
