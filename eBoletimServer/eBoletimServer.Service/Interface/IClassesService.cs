using eBoletimServer.Domain.Models;
using eBoletimServer.Service.Interface.Base;

namespace eBoletimServer.Service.Interface
{
    public interface IClassesService : IBaseService<Classes>
    {
        Task<ReturnObject> Insert(Classes classe);
        Task<ReturnObject> Update(Classes classe);
    }
}