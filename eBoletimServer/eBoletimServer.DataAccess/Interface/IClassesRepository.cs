using eBoletimServer.DataAccess.Interface.Base;
using eBoletimServer.Domain.Models;

namespace eBoletimServer.DataAccess.Interface
{
    public interface IClassesRepository : IBaseRepository<Classes>
    {
        Task<Classes> Select(Classes classes);
    }
}