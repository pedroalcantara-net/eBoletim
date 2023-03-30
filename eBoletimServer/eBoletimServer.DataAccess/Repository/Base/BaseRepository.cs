using eBoletim.Server.CrossCutting;
using eBoletimServer.DataAccess.Interface.Base;
using eBoletimServer.Domain.Models;
using eBoletimServer.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace eBoletimServer.DataAccess.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected readonly EBoletimDbContext _context;
        protected readonly DbSet<T> _db;

        public BaseRepository(EBoletimDbContext context)
        {
            _context = context;
            _db = context.Set<T>();
        }

        #region Listar T
        public async Task<T> Select(T entity)
        {
            try
            {
                return await _db.FirstOrDefaultAsync(ent => entity.Id == null || ent.Id == entity.Id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<T>> SelectAll()
        {
            try
            {
                return await _db.ToListAsync();
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region CRUD T
        public async Task<ReturnObject> Insert(T entity)
        {
            var returnObject = new ReturnObject();

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _db.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    returnObject.Status = true;
                    returnObject.Message = "Successful transaction";
                    returnObject.Code = 200;
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    returnObject = Util.CreateInternalServerError(ex);
                }
            }

            return returnObject;
        }

        public async Task<ReturnObject> Update(T entity)
        {
            var returnObject = new ReturnObject();

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _db.Update(entity);
                    await _context.SaveChangesAsync();
                    returnObject.Status = true;
                    returnObject.Message = "Successful transaction";
                    returnObject.Code = 200;
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    returnObject = Util.CreateInternalServerError(ex);
                }
            }

            return returnObject;
        }

        public async Task<ReturnObject> Delete(T entity)
        {
            var returnObject = new ReturnObject();

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _db.Remove(entity);
                    await _context.SaveChangesAsync();
                    returnObject.Status = true;
                    returnObject.Message = "Successful transaction";
                    returnObject.Code = 200;
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    returnObject = Util.CreateInternalServerError(ex);
                }
            }

            return returnObject;
        }
        #endregion
    }
}
