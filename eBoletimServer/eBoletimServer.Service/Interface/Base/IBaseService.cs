using eBoletimServer.Domain.Models;

namespace eBoletimServer.Service.Interface.Base
{
    public interface IBaseService<T> where T : BaseModel
    {
        Task<ReturnObject> Delete(T entity);
        Task<ReturnObject> DeleteById(int id);
        Task<List<T>> Get();
        Task<T> GetById(int id);
    }
}