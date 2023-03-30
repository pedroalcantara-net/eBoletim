using eBoletimServer.Domain.Models;
using eBoletimServer.Service.Interface.Base;

namespace eBoletimServer.Service.Interface
{
    public interface IRolesService : IBaseService<Roles>
    {
        Task<ReturnObject> Insert(string tempRole);
        Task<ReturnObject> Update(Roles role);
    }
}