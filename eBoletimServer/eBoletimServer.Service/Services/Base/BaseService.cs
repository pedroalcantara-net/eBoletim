using eBoletim.Server.CrossCutting;
using eBoletimServer.DataAccess.Interface.Base;
using eBoletimServer.Domain.Models;
using eBoletimServer.Service.Interface.Base;

namespace eBoletimServer.Service.Services.Base
{
    public class BaseService<T, TRepository> : IBaseService<T> where T : BaseModel where TRepository : IBaseRepository<T>
    {
        protected readonly TRepository _repository;
        public BaseService(TRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<T>> Get()
        {
            return await _repository.SelectAll();
        }

        public async Task<T> GetById(int id)
        {
            T entity = (T)Activator.CreateInstance(typeof(T));
            entity.Id = id;

            return await _repository.Select(entity);
        }

        public async Task<ReturnObject> Delete(T entity)
        {
            var returnObject = new ReturnObject();

            try
            {
                returnObject = await _repository.Delete(entity);
            }
            catch (Exception ex)
            {
                returnObject = Util.CreateInternalServerError(ex);
            }

            return returnObject;
        }

        public async Task<ReturnObject> DeleteById(int id)
        {
            var returnObject = new ReturnObject();

            try
            {
                T entity = (T)Activator.CreateInstance(typeof(T));
                entity.Id = id;

                returnObject = await _repository.Delete(entity);
            }
            catch (Exception ex)
            {
                returnObject = Util.CreateInternalServerError(ex);
            }

            return returnObject;
        }
    }
}
