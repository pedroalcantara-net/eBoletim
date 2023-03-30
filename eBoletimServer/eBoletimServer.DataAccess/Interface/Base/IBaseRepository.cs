using eBoletimServer.Domain.Models;

namespace eBoletimServer.DataAccess.Interface.Base
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<ReturnObject> Delete(T entity);
        Task<ReturnObject> Insert(T entity);
        Task<List<T>> SelectAll();
        Task<T> Select(T entity);
        Task<ReturnObject> Update(T entity);
    }
}