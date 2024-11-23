using Microsoft.AspNetCore.Http;

namespace CafeOrderManagementSystem.Application.UserManagement
{
    public static class CurrentUser
    {
         static IHttpContextAccessor _httpContextAccessor = default!;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public static int Id
        {
            get
            {
                var userIdClaim = _httpContextAccessor.HttpContext?.User?.Claims
                    .FirstOrDefault(c => c.Type == "UserId");

                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out var userId))
                {
                    return userId;
                }

                throw new Exception("Geçerli Kullanıcı Yok.");
            }
        }
        public static string UserInfo
        {
            get
            {
               
                var firstName = _httpContextAccessor.HttpContext?.User?.Claims
                    .FirstOrDefault(c => c.Type == "FirstName")!.Value;
                var lastName = _httpContextAccessor.HttpContext?.User?.Claims
                    .FirstOrDefault(c => c.Type == "LastName")!.Value;

                return $"{firstName} {lastName}";
                
            }
        }
    }
}
