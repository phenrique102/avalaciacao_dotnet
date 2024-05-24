using Web.Models.Login;

namespace Web.Services.Authentication
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
    }
}
