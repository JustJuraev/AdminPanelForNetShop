using AdminPanel.Models.ViewModel;
using System.Security.Claims;

namespace AdminPanel.Service.Interfaces
{
    public interface IAccountService
    {
        ClaimsIdentity Login(LoginViewModel model);
    }
}
