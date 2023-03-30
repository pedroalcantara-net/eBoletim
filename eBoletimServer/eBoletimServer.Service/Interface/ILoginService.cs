using eBoletimServer.Domain.Models;
using eBoletimServer.Domain.Models.ViewModels;

namespace eBoletimServer.Service.Interface
{
    public interface ILoginService
    {
        Task<ReturnObject> Login(LoginModel login);
    }
}