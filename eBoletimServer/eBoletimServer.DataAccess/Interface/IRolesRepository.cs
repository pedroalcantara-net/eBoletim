using eBoletimServer.DataAccess.Interface.Base;
using eBoletimServer.Domain.Models;

namespace eBoletimServer.DataAccess.Interface
{
    public interface IRolesRepository : IBaseRepository<Roles>
    {
        Task<Roles> Select(Roles role);
    }
}